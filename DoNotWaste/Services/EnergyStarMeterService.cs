using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class EnergyStarMeterService(IHttpClient httpClient) : IEnergyStarMeterService
{
    public async Task<EnergyStarResponse> GetMeterList(int propertyId, bool accessOnly = true)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient()).GetMeterList(propertyId);
    }

    public async Task<EnergyStarMeterData> GetMeterData(int meterId, int? page, DateTime startDate, DateTime endDate)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient()).GetMeterData(meterId,
            null, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
    }
    
    public async Task<EnergyStarResponse> CreateMeter(int propertyId, EnergyStarMeter meter)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient())
            .CreateMeter(propertyId, meter);
    }

    public async Task<EnergyStarMeterData> AddMeterData(int meterId, EnergyStarMeterData meterData)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient())
            .AddMeterData(meterId, meterData);
    }

    public async Task<EnergyStarResponse> ModifyConsumptionData(int consumptionDataId, EnergyStarMeterData meterData)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient())
            .ModifyConsumptionData(consumptionDataId, meterData);
    }
}