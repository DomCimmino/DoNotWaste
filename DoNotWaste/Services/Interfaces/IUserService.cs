using DoNotWaste.Models;

namespace DoNotWaste.Services.Interfaces;

public interface IUserService
{
    Task<Account> GetUser();
    Task<EnergyStarResponse> CreateUser(Account account);
}