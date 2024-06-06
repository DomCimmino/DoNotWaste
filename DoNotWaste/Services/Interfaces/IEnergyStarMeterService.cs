using DoNotWaste.Models.EnergyStarModels;

namespace DoNotWaste.Services.Interfaces;

public interface IEnergyStarMeterService
{
    Task<EnergyStarResponse> GetMeterList(int propertyId, bool accessOnly = true);
    Task<EnergyStarMeterData> GetMeterData(int meterId, int? page, DateTime startDate, DateTime endDate);
    Task<EnergyStarResponse> CreateMeter(int propertyId, EnergyStarMeter meter);
    Task<EnergyStarResponse> ModifyConsumptionData(int consumptionDataId, EnergyStarMeterData meterData);
}