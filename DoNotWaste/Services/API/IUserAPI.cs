using DoNotWaste.Models.AssetScoreModels;
using DoNotWaste.Models.EnergyStarModels;
using Refit;

namespace DoNotWaste.Services.API;

public interface IUserApi
{
    [Headers("Authorization: Basic Auth")]
    [Get("/account")]
    Task<EnergyStarAccount> GetEnergyStarAccount();
    
    [Post("/account")]
    Task<EnergyStarResponse> CreateEnergyStarAccount([Body(BodySerializationMethod.Serialized)] EnergyStarAccount account);

    [Post("/api/v2/users/authenticate")]
    Task<AuthenticationResponse> GetAssetScoreToken([Body(BodySerializationMethod.Default)] AuthenticationRequest account);
}