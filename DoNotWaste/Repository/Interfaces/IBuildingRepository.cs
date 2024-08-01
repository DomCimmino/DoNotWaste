using DoNotWaste.DTO;
using DoNotWaste.Models.DataModel;

namespace DoNotWaste.Repository.Interfaces;

public interface IBuildingRepository
{
    ResidentialBuilding GetResidential(NumberResidentialBuildings residentialNumber);
    IndustrialBuilding GetIndustrial(NumberIndustrialBuildings industrialNumber);
    List<DeviceRecordDto> GetSingleBuildingDevicesConsumptions<T>(T building) where T : BaseBuilding;
    List<DeviceRecordDto> CalculateDeviceConsumptionsForAllBuildings(bool isResidential = true, bool isAverage = true);
    List<DeviceRecordDto> GetBuildingTypePhotovoltaicProduction(bool isResidential = true);
    List<DeviceRecordDto> GetSingleBuildingPhotovoltaicProduction<T>(T building) where T : BaseBuilding;
} 