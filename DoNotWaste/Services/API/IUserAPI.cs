using DoNotWaste.Models;
using Refit;

namespace DoNotWaste.Services.API;

public interface IUserApi
{
    [Headers("Authorization: Basic Auth")]
    [Get("/account")]
    Task<Account> GetUser();
    
    [Post("/account")]
    Task<EnergyStarResponse> CreateUser([Body(BodySerializationMethod.Default)] Account account);
}