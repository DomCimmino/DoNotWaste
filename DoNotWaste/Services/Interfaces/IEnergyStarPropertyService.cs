using DoNotWaste.Models.EnergyStarModels;

namespace DoNotWaste.Services.Interfaces;

public interface IEnergyStarPropertyService
{
    Task<EnergyStarResponse> GetPropertiesList(int accountId);
    Task<EnergyStarResponse> CreateProperty(int accountId, EnergyStarProperty property);
}