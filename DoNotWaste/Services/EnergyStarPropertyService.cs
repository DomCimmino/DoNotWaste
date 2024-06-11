using DoNotWaste.Models;
using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class EnergyStarPropertyService(IHttpClient httpClient) : IEnergyStarPropertyService
{
    public async Task<EnergyStarResponse> GetPropertiesList(int accountId)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient()).GetPropertiesList(accountId);
    }

    public async Task<EnergyStarProperty> GetProperty(int propertyId)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient()).GetProperty(propertyId);
    }

    public async Task<EnergyStarWeatherStation> GetWeatherStations(Country country, int? page = null)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient())
            .GetWeatherStations(page, Enum.GetName(country) );
    }

    public async Task<EnergyStarResponse> CreateProperty(int accountId, EnergyStarProperty property)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient()).CreateProperty(accountId, property);
    }

    public async Task<EnergyStarResponse> CreatePropertyUse(int propertyId, EnergyStarResidentialUse residentialUse)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient())
            .CreatePropertyUse(propertyId, residentialUse);
    }

    public async Task<EnergyStarResponse> AddWeatherStationToProperty(int propertyId, int internationalWeatherStationId)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient()).AddWeatherStationToProperty(propertyId, internationalWeatherStationId);
    }

    public async Task<EnergyStarResponse> DeleteProperty(int propertyId)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient()).DeleteProperty(propertyId);
    }
}