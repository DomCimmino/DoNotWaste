using DoNotWaste.Models;
using DoNotWaste.Models.AssetScoreModels.Request;
using DoNotWaste.Models.AssetScoreModels.Response;
using Refit;

namespace DoNotWaste.Services.API;

public interface IUserApi
{
    [Headers("Authorization: Basic Auth")]
    [Get("/account")]
    Task<Account> GetEnergyStarUser();
    
    [Post("/account")]
    Task<EnergyStarResponse> CreateEnergyStarUser([Body(BodySerializationMethod.Default)] Account account);
    
    [Post("/users/authenticate")]
    Task<AuthenticationResponse> GetAssetScoreToken([Body(BodySerializationMethod.Default)] AuthenticationRequest account);
}