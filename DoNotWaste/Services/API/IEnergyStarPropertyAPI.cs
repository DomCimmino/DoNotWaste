using DoNotWaste.Models.EnergyStarModels;
using Refit;

namespace DoNotWaste.Services.API;

[Headers("Authorization: Basic Auth")]
public interface IEnergyStarPropertyApi
{
    [Get("/account/{accountId}/property/list")]
    Task<EnergyStarResponse> GetPropertiesList(int accountId);
    
    [Get("/property/{propertyId}")]
    Task<EnergyStarProperty> GetProperty(int propertyId);

    [Get("/property/internationalWeatherStation/list?page={page}&country={country}")]
    Task<EnergyStarWeatherStation> GetWeatherStations(int? page, string? country);

    [Post("/account/{accountId}/property")]
    Task<EnergyStarResponse> CreateProperty(int accountId, [Body(BodySerializationMethod.Serialized)] EnergyStarProperty property);

    [Post("/property/{propertyId}/propertyUse")]
    Task<EnergyStarResponse> CreatePropertyUse(int propertyId, [Body(BodySerializationMethod.Serialized)] EnergyStarResidentialUse residentialUse);

    [Put("/property/{propertyId}/internationalWeatherStation/{internationalWeatherStationId}")]
    Task<EnergyStarResponse> AddWeatherStationToProperty(int propertyId, int internationalWeatherStationId);
    
    [Delete("/property/{propertyId}")]
    Task<EnergyStarResponse> DeleteProperty(int propertyId);
}