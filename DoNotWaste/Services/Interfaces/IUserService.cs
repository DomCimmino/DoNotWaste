using DoNotWaste.Models.EnergyStarModels;

namespace DoNotWaste.Services.Interfaces;

public interface IUserService
{
    Task<EnergyStarAccount> GetEnergyStarAccount();
    Task<EnergyStarResponse> CreateEnergyStarAccount(EnergyStarAccount account);
}