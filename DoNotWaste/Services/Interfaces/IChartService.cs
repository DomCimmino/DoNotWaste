using DoNotWaste.Models.DataModel;

namespace DoNotWaste.Services.Interfaces;

public interface IChartService
{
    (string[] Labels, double[] Data) GetSingleBuildingDataChart(NumberResidentialBuildings numberBuilding);
    (string[] Labels, double[] Data) GetResidentialMeanDataChart();
    (string[] Labels, double[] Data) GetIndustrialMeanDataChart();
}