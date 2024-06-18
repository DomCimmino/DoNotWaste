using DoNotWaste.Models.DataModel;
using DoNotWaste.Repository.Interfaces;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class ChartService(IBuildingRepository buildingRepository) : IChartService
{
    public (string[] Labels, double[] Data) GetDataChart()
    {
        var labels = new List<string>();
        var data = new List<double>();

        var culture = new System.Globalization.CultureInfo("en-US");

        var building = buildingRepository.GetResidential(NumberResidentialBuildings.Fourth);
        
        foreach (var item in building.MonthlyTotal())
        {
            labels.Add(item.StartDate.ToString("MMM. yy", culture));
            data.Add(item.TotalConsumption ?? 0);
        }
        
        return ([.. labels], [.. data]);
    }
}