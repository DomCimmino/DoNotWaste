using DoNotWaste.DTO;
using DoNotWaste.Models.DataModel;

namespace DoNotWaste.Repository.Interfaces;

public interface IBuildingRepository
{
    ResidentialBuilding GetResidential(NumberResidentialBuildings residentialNumber);
    IndustrialBuilding GetIndustrial(NumberIndustrialBuildings industrialNumber);
    IEnumerable<DeviceConsumptionDto> GetOrderedDeviceConsumptions<T>(T building) where T : BaseBuilding;
    List<DeviceConsumptionDto> CalculateAverageDeviceConsumptionsForAllBuildings(bool isResidential = true);
}