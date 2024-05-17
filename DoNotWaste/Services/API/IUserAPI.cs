using System.Net;
using Refit;

namespace DoNotWaste.Services.API;

public interface IUserApi
{
    [Headers("Authorization: Basic Auth")]
    [Get("/account")]
    Task<HttpWebResponse> GetUser();
    
    [Post("/account")]
    Task<HttpWebResponse> CreateUser([Body(BodySerializationMethod.Default)] Account account);
}