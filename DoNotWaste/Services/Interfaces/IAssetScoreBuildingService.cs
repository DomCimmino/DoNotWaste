using DoNotWaste.Models.AssetScoreModels;

namespace DoNotWaste.Services.Interfaces;

public interface IAssetScoreBuildingService
{
    Task<BuildingResponse> CreateSimpleBuildings(AssetScoreSimpleBuilding simpleBuildingRequest);
    Task<List<BuildingResponse>> GetBuildings();
    Task<BuildingResponse> GetBuildingById(int buildingId);
    Task<byte[]> GetReport(int buildingId);
}