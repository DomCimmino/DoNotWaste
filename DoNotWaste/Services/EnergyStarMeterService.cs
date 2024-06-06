using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class EnergyStarMeterService(IHttpClient httpClient) : IEnergyStarMeterService
{
    public async Task<EnergyStarMeterData> GetMeterData(int meterId, int? page, DateTime startDate, DateTime endDate)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient()).GetMeterData(meterId,
            null, startDate.ToString("YYYY-MM-DD"), endDate.ToString("YYYY-MM-DD"));
    }

    public async Task<EnergyStarResponse> CreateMeter(int propertyId, EnergyStarMeter meter)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient())
            .CreateMeter(propertyId, meter);
    }

    public async Task<EnergyStarResponse> ModifyConsumptionData(int consumptionDataId, EnergyStarMeterData meterData)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient())
            .ModifyConsumptionData(consumptionDataId, meterData);
    }
}