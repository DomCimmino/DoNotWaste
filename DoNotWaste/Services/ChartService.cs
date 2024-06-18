using System.Globalization;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Repository.Interfaces;
using DoNotWaste.Services.Interfaces;
using DateTime = System.DateTime;

namespace DoNotWaste.Services;

public class ChartService(IBuildingRepository buildingRepository) : IChartService
{
    private readonly CultureInfo _cultureInfo = new("en-US");

    public (string[] Labels, double[] Data) GetSingleBuildingDataChart(NumberResidentialBuildings numberBuilding)
    {
        var labels = new List<string>();
        var data = new List<double>();

        var building = buildingRepository.GetResidential(numberBuilding);

        foreach (var item in building.MonthlyTotal())
        {
            labels.Add(item.StartDate.ToString("MMM. yy", _cultureInfo));
            data.Add(item.TotalConsumption ?? 0);
        }

        return ([.. labels], [.. data]);
    }

    public (string[] Labels, double[] Data) GetMeanDataChart()
    {
        var allMonthlyTotal = new List<(DateTime StartDate, DateTime EndDate, double? consumption)>();
        var labels = new List<string>();
        var data = new List<double>();

        foreach (NumberResidentialBuildings number in Enum.GetValues(typeof(NumberResidentialBuildings)))
        {
            var building = buildingRepository.GetResidential(number);
            allMonthlyTotal.AddRange(building.MonthlyTotal());
        }
        
        var monthlyDictionaryDivision = new Dictionary<DateTime, List<(DateTime StartDate, DateTime EndDate, double? consumption)>>();

        foreach (var item in allMonthlyTotal)
        {
            if (!monthlyDictionaryDivision.TryGetValue(item.StartDate, out var list))
            {
                list = new List<(DateTime StartDate, DateTime EndDate, double? consumption)>();
                monthlyDictionaryDivision[item.StartDate] = list;
            }
            list.Add(item);
        }
        
        foreach (var startDate in monthlyDictionaryDivision.Keys.OrderBy(d => d))
        {
            labels.Add(startDate.ToString("MMM. yy", _cultureInfo));
            data.Add(monthlyDictionaryDivision[startDate].Average(x => x.consumption ?? 0));
        }

        return ([.. labels], [.. data]);
    }
}