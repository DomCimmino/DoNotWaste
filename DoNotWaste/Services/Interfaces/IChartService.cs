using DoNotWaste.DTO;
using DoNotWaste.Models.DataModel;

namespace DoNotWaste.Services.Interfaces;

public interface IChartService
{
    ChartDataDto GetSingleBuildingDataChart<T>(T numberBuilding) where T : Enum;
    List<DeviceRecordDto> GetSingleBuildingDevicesConsumptionData<T>(T numberBuilding) where T : Enum;
    ChartDataDto GetMeanDataChart(bool isResidential = true);
    List<DeviceRecordDto> GetAverageDataProgressBar(bool isResidential = true);
    List<DeviceRecordDto> GetSumConsumptionDataByType(bool isResidential = true);
    public double GetSumProductionDataByType(bool isResidential = true);
    double GetSumImportGridDataByType(bool isResidential = true);
    double GetSumProductionDataById<T>(T numberBuilding) where T : Enum;
    double GetSumImportGridDataById<T>(T numberBuilding) where T : Enum;
}