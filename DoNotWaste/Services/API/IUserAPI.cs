using DoNotWaste.Models;
using DoNotWaste.Models.AssetScoreModels.Request;
using DoNotWaste.Models.AssetScoreModels.Response;
using Refit;

namespace DoNotWaste.Services.API;

public interface IUserApi
{
    [Headers("Authorization: Basic Auth")]
    [Get("/account")]
    Task<EnergyStarAccount> GetEnergyStarAccount();
    
    [Post("/account")]
    Task<EnergyStarResponse> CreateEnergyStarAccount([Body(BodySerializationMethod.Serialized)] EnergyStarAccount account);

    [Post("/users/authenticate")]
    Task<AuthenticationResponse> GetAssetScoreToken([Body(BodySerializationMethod.Default)] AuthenticationRequest account);
}