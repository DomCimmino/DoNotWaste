using DoNotWaste.Models.EnergyStarModels;
using Refit;

namespace DoNotWaste.Services.API;

public interface IUserApi
{
    [Headers("Authorization: Basic Auth")]
    [Get("/account")]
    Task<EnergyStarAccount> GetUser();
    
    [Post("/account")]
    Task<EnergyStarResponse> CreateUser([Body(BodySerializationMethod.Default)] EnergyStarAccount energyStarAccount);
}