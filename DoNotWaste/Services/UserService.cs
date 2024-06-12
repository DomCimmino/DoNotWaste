using DoNotWaste.Models;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class UserService(IHttpClient httpClient) : IUserService
{
    public async Task<Account> GetEnergyStarUser()
    {
        return await RefitExtensions.For<IUserApi>(await httpClient.GetHttpClient()).GetEnergyStarUser();
    }

    public async Task<EnergyStarResponse> CreateEnergyStarUser(Account account)
    {
        return await RefitExtensions.For<IUserApi>(await httpClient.GetHttpClient()).CreateEnergyStarUser(account);
    }
}