using DoNotWaste.Models.EnergyStarModels;
using Refit;

namespace DoNotWaste.Services.API;

[Headers("Authorization: Basic Auth")]
public interface IEnergyStarMeterApi
{
    [Get("/meter/{meterId}/consumptionData?page={page}&startDate={YYYY-MM-DD}&endDate={YYYY-MM-DD}")]
    Task<EnergyStarMeterData> GetMeterData(int meterId, int? page, string startDate, string endDate);

    [Post("/property/{propertyId}/meter")]
    Task<EnergyStarResponse> CreateMeter(int propertyId, [Body(BodySerializationMethod.Serialized)] EnergyStarMeter meter);

    [Put("/consumptionData/{consumptionDataId}")]
    Task<EnergyStarResponse> ModifyConsumptionData(int consumptionDataId, [Body(BodySerializationMethod.Serialized)] EnergyStarMeterData meterData);
}