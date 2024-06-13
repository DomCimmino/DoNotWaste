using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class UserService(IHttpClient httpClient) : IUserService
{
    public async Task<Account> GetEnergyStarUser()
    {
        return await RefitExtensions.For<IUserApi>(await httpClient.GetHttpClient()).GetEnergyStarAccount();
    }

    public async Task<EnergyStarResponse> CreateEnergyStarAccount(EnergyStarAccount account)
    {
        return await RefitExtensions.For<IUserApi>(await httpClient.GetHttpClient()).CreateEnergyStarAccount(account);
    }
}