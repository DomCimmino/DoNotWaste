using DoNotWaste.Models.EnergyStarModels;
using Refit;

namespace DoNotWaste.Services.API;

public interface IEnergyStarPropertyAPI
{
    [Headers("Authorization: Basic Auth")]
    [Get("/account/{accountId}/property/list")]
    Task<EnergyStarResponse> GetPropertiesList(int accountId);
}