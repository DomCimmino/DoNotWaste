using DoNotWaste.DTO;
using DoNotWaste.Models.DataModel;

namespace DoNotWaste.Services.Interfaces;

public interface IChartService
{
    ChartDataDto GetSingleBuildingDataChart(NumberResidentialBuildings numberBuilding);
    ChartDataDto GetResidentialMeanDataChart();
    ChartDataDto GetIndustrialMeanDataChart();
    List<DeviceConsumptionDto> GetResidentialDataProgressBar(NumberResidentialBuildings numberBuilding);
    List<DeviceConsumptionDto> GetIndustrialDataProgressBar(NumberIndustrialBuildings numberBuilding);
}