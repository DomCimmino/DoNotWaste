using System.Globalization;
using DoNotWaste.DTO;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Repository.Interfaces;
using DoNotWaste.Services.Interfaces;
using DateTime = System.DateTime;

namespace DoNotWaste.Services;

public class ChartService(IBuildingRepository buildingRepository) : IChartService
{
    private readonly CultureInfo _cultureInfo = new("en-US");
    
    public ChartDataDto GetSingleBuildingDataChart<T>(T numberBuilding) where T : Enum
    {
        var labels = new List<string>();
        var data = new List<double>();
        var building = new BaseBuilding();
        var chartData = new ChartDataDto();

        if (typeof(T) == typeof(NumberResidentialBuildings))
        {
            var number = (NumberResidentialBuildings)(object)numberBuilding;
            building = buildingRepository.GetResidential(number);
            chartData.BuildingTypeId = 1;
            chartData.BuildingTypeName = "Residential";
            chartData.Id = (int?)number;
            chartData.BuildingName = Enum.GetName(number);
        }
        else if (typeof(T) == typeof(NumberIndustrialBuildings))
        {
            var number = (NumberIndustrialBuildings)(object)numberBuilding;
            building = buildingRepository.GetIndustrial((NumberIndustrialBuildings)(object)numberBuilding);
            chartData.BuildingTypeId = 2;
            chartData.BuildingTypeName = "Industrial";
            chartData.Id = (int?)number;
            chartData.BuildingName = Enum.GetName(number);
        }

        foreach (var item in building.MonthlyTotal())
        {
            labels.Add(item.StartDate.ToString("MMMM yyyy", _cultureInfo));
            data.Add(item.Consumption ?? 0);
        }

        chartData.Labels = labels;
        chartData.Data = data;
        return chartData;
    }

    public ChartDataDto GetResidentialMeanDataChart()
    {
        return GetMeanDataChart<NumberResidentialBuildings>(buildingRepository.GetResidential);
    }

    public ChartDataDto GetIndustrialMeanDataChart()
    {
        return GetMeanDataChart<NumberIndustrialBuildings>(buildingRepository.GetIndustrial);
    }

    public List<DeviceConsumptionDto> GetResidentialDataProgressBar(NumberResidentialBuildings numberBuilding)
    {
        return buildingRepository
            .GetOrderedDeviceConsumptions(buildingRepository.GetResidential(numberBuilding))
            .ToList();
    }

    public List<DeviceConsumptionDto> GetIndustrialDataProgressBar(NumberIndustrialBuildings numberBuilding)
    {
        return buildingRepository
            .GetOrderedDeviceConsumptions(buildingRepository.GetIndustrial(numberBuilding))
            .ToList();
    }

    private ChartDataDto GetMeanDataChart<T>(Func<T, BaseBuilding> getBuildingFunc) where T : Enum
    {
        var allMonthlyTotal = new List<ConsumptionRecord>();
        var labels = new List<string>();
        var data = new List<double>();

        foreach (T number in Enum.GetValues(typeof(T)))
        {
            var building = getBuildingFunc(number);
            allMonthlyTotal.AddRange(building.MonthlyTotal());
        }

        var monthlyDictionaryDivision = new Dictionary<DateTime, List<ConsumptionRecord>>();

        foreach (var item in allMonthlyTotal)
        {
            if (!monthlyDictionaryDivision.TryGetValue(item.StartDate, out var list))
            {
                list = new List<ConsumptionRecord>();
                monthlyDictionaryDivision[item.StartDate] = list;
            }

            list.Add(item);
        }

        foreach (var startDate in monthlyDictionaryDivision.Keys.OrderBy(d => d))
        {
            labels.Add(startDate.ToString("MMM. yy", _cultureInfo));
            data.Add(monthlyDictionaryDivision[startDate].Average(x => x.Consumption ?? 0));
        }

        return new ChartDataDto { Labels = labels, Data = data };
    }
}