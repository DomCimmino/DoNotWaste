using DoNotWaste.Models.EnergyStarModels;
using Refit;

namespace DoNotWaste.Services.API;

[Headers("Authorization: Basic Auth")]
public interface IEnergyStarPropertyApi
{
    [Get("/account/{accountId}/property/list")]
    Task<EnergyStarResponse> GetPropertiesList(int accountId);

    [Post("/account/{accountId}/property")]
    Task<EnergyStarResponse> CreateProperty(int accountId, [Body(BodySerializationMethod.Serialized)] EnergyStarProperty property);
}