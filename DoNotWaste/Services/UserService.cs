using DoNotWaste.Models;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class UserService(IHttpClient httpClient) : IUserService
{
    public async Task<Account> GetUser()
    {
        return await RefitExtensions.For<IUserApi>(await httpClient.GetHttpClient()).GetUser();
    }

    public async Task<EnergyStarResponse> CreateUser(Account account)
    {
        return await RefitExtensions.For<IUserApi>(await httpClient.GetHttpClient()).CreateUser(account);
    }
}