using DoNotWaste.DTO;
using DoNotWaste.Models.AssetScoreModels;

namespace DoNotWaste.Services.Interfaces;

public interface IAssetScoreBuildingService
{
    Task<BuildingResponse> CreateSimpleBuildings(AssetScoreSimpleBuilding simpleBuildingRequest);
    Task<List<BuildingDto>> GetBuildings();
    Task<BuildingDto> GetBuildingById(int buildingId);
    Task<byte[]> GetReport(int buildingId);
    Task<List<Recommendation>> GetRecommendations(int buildingId);
}