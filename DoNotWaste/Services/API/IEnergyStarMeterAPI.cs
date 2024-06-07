using DoNotWaste.Models.EnergyStarModels;
using Refit;

namespace DoNotWaste.Services.API;

[Headers("Authorization: Basic Auth")]
public interface IEnergyStarMeterApi
{
    [Get("/property/{propertyId}/meter/list")]
    Task<EnergyStarResponse> GetMeterList(int propertyId, [Query] bool accessOnly = true);
    
    [Get("/meter/{meterId}/consumptionData")]
    Task<EnergyStarMeterData> GetMeterData(int meterId, [Query] int? page, [Query] string startDate, [Query] string endDate);
    
    [Post("/property/{propertyId}/meter")]
    Task<EnergyStarResponse> CreateMeter(int propertyId, [Body(BodySerializationMethod.Serialized)] EnergyStarMeter meter);
    
    [Post("/meter/{meterId}/consumptionData")]
    Task<EnergyStarMeterData> AddMeterData(int meterId, [Body(BodySerializationMethod.Serialized)] EnergyStarMeterData meterData);

    [Put("/consumptionData/{consumptionDataId}")]
    Task<EnergyStarResponse> ModifyConsumptionData(int consumptionDataId, [Body(BodySerializationMethod.Serialized)] EnergyStarMeterData meterData);
}