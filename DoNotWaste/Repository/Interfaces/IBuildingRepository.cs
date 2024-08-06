using DoNotWaste.DTO;
using DoNotWaste.Models.DataModel;

namespace DoNotWaste.Repository.Interfaces;

public interface IBuildingRepository
{
    ResidentialBuilding GetResidential(NumberResidentialBuildings residentialNumber);
    IndustrialBuilding GetIndustrial(NumberIndustrialBuildings industrialNumber);
    List<DeviceRecordDto> GetSingleBuildingDevicesConsumptions<T>(T building) where T : BaseBuilding;
    List<DeviceRecordDto> CalculateDeviceConsumptionsForAllBuildings(bool isResidential = true, bool isAverage = true);
    IEnumerable<DeviceRecordDto> GetBuildingTypePhotovoltaicProduction(bool isResidential = true);
    IEnumerable<DeviceRecordDto> GetSingleBuildingPhotovoltaicProduction<T>(T building) where T : BaseBuilding;
    IEnumerable<DeviceRecordDto> GetSingleBuildingGridImport<T>(T building) where T : BaseBuilding;
    IEnumerable<DeviceRecordDto> GetBuildingTypeImportGrid(bool isResidential = true);
} 