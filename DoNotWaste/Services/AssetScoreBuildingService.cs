using DoNotWaste.Models.AssetScoreModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class AssetScoreBuildingService(IHttpClient httpClient) : IAssetScoreBuildingService
{
    public async Task<int> CreateSimpleBuildings(SimpleBuildingRequest simpleBuildingRequest)
    {
        return await RefitExtensions.For<IAssetScoreBuildingApi>(await httpClient.GetHttpClient(false), false)
            .CreateSimpleBuildings(simpleBuildingRequest);
    }
}