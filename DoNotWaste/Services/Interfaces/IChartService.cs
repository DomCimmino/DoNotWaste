using DoNotWaste.DTO;
using DoNotWaste.Models.DataModel;

namespace DoNotWaste.Services.Interfaces;

public interface IChartService
{
    ChartDataDto GetSingleBuildingDataChart<T>(T numberBuilding) where T : Enum;
    ChartDataDto GetResidentialMeanDataChart();
    ChartDataDto GetIndustrialMeanDataChart();
    List<DeviceConsumptionDto> GetResidentialDataProgressBar(NumberResidentialBuildings numberBuilding);
    List<DeviceConsumptionDto> GetIndustrialDataProgressBar(NumberIndustrialBuildings numberBuilding);
}