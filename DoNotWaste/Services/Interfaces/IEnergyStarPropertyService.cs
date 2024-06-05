using DoNotWaste.Models.EnergyStarModels;

namespace DoNotWaste.Services.Interfaces;

public interface IEnergyStarPropertyService
{
    Task<EnergyStarResponse> GetPropertiesList(int accountId);
}