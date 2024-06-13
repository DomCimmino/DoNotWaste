using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class UserService(IHttpClient httpClient) : IUserService
{
    public async Task<EnergyStarAccount> GetEnergyStarAccount()
    {
        return await RefitExtensions.For<IUserApi>(await httpClient.GetHttpClient()).GetUser();
    }

    public async Task<EnergyStarResponse> CreateEnergyStarAccount(EnergyStarAccount energyStarAccount)
    {
        return await RefitExtensions.For<IUserApi>(await httpClient.GetHttpClient()).CreateUser(energyStarAccount);
    }
}