using DoNotWaste.Models.EnergyStarModels;

namespace DoNotWaste.Services.Interfaces;

public interface IEnergyStarMeterService
{
    Task<EnergyStarResponse> GetMeterList(int propertyId, bool accessOnly = true);
    Task<EnergyStarMeter> GetMeter(int meterId);
    Task<EnergyStarMeterData> GetMeterData(int meterId, int? page, DateTime startDate, DateTime endDate);
    Task<EnergyStarResponse> CreateMeter(int propertyId, EnergyStarMeterRequest meter);
    Task<EnergyStarMeterData> AddMeterData(int meterId, EnergyStarMeterData meterData);
    Task<EnergyStarResponse> AssociateMeterToProperty(int propertyId, int meterId);
    Task<EnergyStarResponse> ModifyConsumptionData(int consumptionDataId, EnergyStarMeterData meterData);
    Task<EnergyStarResponse> DeleteMeter(int meterId);
}