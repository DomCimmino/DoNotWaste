using DoNotWaste.DTO;
using DoNotWaste.Models;
using DoNotWaste.Models.EnergyStarModels;

namespace DoNotWaste.Services.Interfaces;

public interface IEnergyStarPropertyService
{
    Task<EnergyStarResponse> GetPropertiesIdList(int accountId);
    Task<BuildingDto> GetDtoProperty(int propertyId);
    Task<EnergyStarProperty> GetProperty(int propertyId);
    Task<EnergyStarWeatherStation> GetWeatherStations(Country country, int? page = null);
    Task<EnergyStarResponse> GetPropertyUseList(int propertyId);
    Task<EnergyStarResponse> CreateProperty(int accountId, EnergyStarProperty property);
    Task<EnergyStarResponse> CreatePropertyUse(int propertyId, EnergyStarResidentialUse residentialUse);
    Task<EnergyStarResponse> AddWeatherStationToProperty(int propertyId, int internationalWeatherStationId);
    Task<EnergyStarResponse> ModifyPropertyUse(int propertyUseId, EnergyStarResidentialUse residentialUse);
    Task<EnergyStarResponse> DeleteProperty(int propertyId);
}