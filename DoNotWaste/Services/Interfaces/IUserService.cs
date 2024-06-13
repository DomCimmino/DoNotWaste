using DoNotWaste.Models.EnergyStarModels;

namespace DoNotWaste.Services.Interfaces;

public interface IUserService
{
    Task<Account> GetEnergyStarUser();
    Task<EnergyStarResponse> CreateEnergyStarUser(Account account);
}