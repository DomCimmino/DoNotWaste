using AutoMapper;
using DoNotWaste.DTO;
using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class EnergyStarMeterService(IHttpClient httpClient, IMapper mapper) : IEnergyStarMeterService
{
    public async Task<EnergyStarResponse> GetMeterList(int propertyId, bool accessOnly = true)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient())
            .GetMeterList(propertyId);
    }

    public async Task<EnergyStarMeter> GetMeter(int meterId)
    {
        var meter = await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient())
            .GetMeter(meterId);
        meter.Id = meterId;
        return meter;
    }

    public async Task<List<MeterDataDto>> GetMeterData(int meterId, int? page, DateTime startDate, DateTime endDate)
    {
        var meterData =  await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient()).GetMeterData(meterId,
            null, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
        return mapper.Map<List<MeterDataDto>>(meterData);
    }

    public async Task<EnergyStarResponse> CreateMeter(int propertyId, EnergyStarMeterRequest meter)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient())
            .CreateMeter(propertyId, meter);
    }

    public async Task<EnergyStarMeterData> AddMeterData(int meterId, EnergyStarMeterData meterData)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient())
            .AddMeterData(meterId, meterData);
    }

    public async Task<EnergyStarResponse> AssociateMeterToProperty(int propertyId, int meterId)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient())
            .AssociateMeterToProperty(propertyId, meterId);
    }

    public async Task<EnergyStarResponse> ModifyConsumptionData(int consumptionDataId, EnergyStarMeterData meterData)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient())
            .ModifyConsumptionData(consumptionDataId, meterData);
    }

    public async Task<EnergyStarResponse> DeleteMeter(int meterId)
    {
        return await RefitExtensions.For<IEnergyStarMeterApi>(await httpClient.GetHttpClient()).DeleteMeter(meterId);
    }
}