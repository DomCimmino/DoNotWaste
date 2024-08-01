using DoNotWaste.DTO;
using DoNotWaste.Models.AssetScoreModels;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.ViewModels;

public class AssetScoreVm(IAssetScoreBuildingService assetScoreBuildingService)
{
    private int? SelectedBuildingId { get; set; }

    public async Task<List<BuildingDto>> LoadBuildings() => await assetScoreBuildingService.GetBuildings();

    public async Task<BuildingDto> LoadBuilding(int buildingId)
    {
        SelectedBuildingId = buildingId;
        return await assetScoreBuildingService.GetBuildingById(SelectedBuildingId ?? -1);
    }
    
    public async Task<List<Recommendation>> LoadBuildingRecommendations() => await assetScoreBuildingService.GetRecommendations(SelectedBuildingId ?? -1);

    public async Task<byte[]> LoadReport() => await assetScoreBuildingService.GetReport(SelectedBuildingId ?? -1);
}