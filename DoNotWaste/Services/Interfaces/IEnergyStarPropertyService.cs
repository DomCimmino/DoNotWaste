using DoNotWaste.Models;
using DoNotWaste.Models.EnergyStarModels;

namespace DoNotWaste.Services.Interfaces;

public interface IEnergyStarPropertyService
{
    Task<EnergyStarResponse> GetPropertiesList(int accountId);
    Task<EnergyStarProperty> GetProperty(int propertyId);
    Task<EnergyStarWeatherStation> GetWeatherStations(Country country, int? page = null);
    Task<EnergyStarResponse> CreateProperty(int accountId, EnergyStarProperty property);
    Task<EnergyStarResponse> AddWeatherStationToProperty(int propertyId, int internationalWeatherStationId);
    Task<EnergyStarResponse> DeleteProperty(int propertyId);
}