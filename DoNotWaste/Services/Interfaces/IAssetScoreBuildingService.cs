using DoNotWaste.Models.AssetScoreModels;

namespace DoNotWaste.Services.Interfaces;

public interface IAssetScoreBuildingService
{
    Task<int> CreateSimpleBuildings(SimpleBuildingRequest simpleBuildingRequest);
}