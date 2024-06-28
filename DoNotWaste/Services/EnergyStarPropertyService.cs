using AutoMapper;
using DoNotWaste.DTO;
using DoNotWaste.Models;
using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class EnergyStarPropertyService(IHttpClient httpClient, IMapper mapper) : IEnergyStarPropertyService
{
    public async Task<EnergyStarResponse> GetPropertiesIdList(int accountId)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient())
            .GetPropertiesList(accountId);
    }

    public async Task<BuildingDto> GetProperty(int propertyId)
    {
        var property = await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient())
            .GetProperty(propertyId);
        property.Id = propertyId;
        return mapper.Map<BuildingDto>(property);
    }

    public async Task<EnergyStarWeatherStation> GetWeatherStations(Country country, int? page = null)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient())
            .GetWeatherStations(page, Enum.GetName(country));
    }

    public async Task<EnergyStarResponse> GetPropertyUseList(int propertyId)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient())
            .GetPropertyUseList(propertyId);
    }

    public async Task<EnergyStarResponse> CreateProperty(int accountId, EnergyStarProperty property)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient())
            .CreateProperty(accountId, property);
    }

    public async Task<EnergyStarResponse> CreatePropertyUse(int propertyId, EnergyStarResidentialUse residentialUse)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient())
            .CreatePropertyUse(propertyId, residentialUse);
    }

    public async Task<EnergyStarResponse> AddWeatherStationToProperty(int propertyId, int internationalWeatherStationId)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient())
            .AddWeatherStationToProperty(propertyId, internationalWeatherStationId);
    }

    public async Task<EnergyStarResponse> ModifyPropertyUse(int propertyUseId, EnergyStarResidentialUse residentialUse)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient())
            .ModifyPropertyUse(propertyUseId, residentialUse);
    }

    public async Task<EnergyStarResponse> DeleteProperty(int propertyId)
    {
        return await RefitExtensions.For<IEnergyStarPropertyApi>(await httpClient.GetHttpClient())
            .DeleteProperty(propertyId);
    }
}