using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class EnergyStarPropertyService(IHttpClient httpClient) : IEnergyStarPropertyService
{
    public async Task<EnergyStarResponse> GetPropertiesList(int accountId)
    {
        return await RefitExtensions.For<IEnergyStarPropertyAPI>(await httpClient.GetHttpClient()).GetPropertiesList(accountId);
    }
}