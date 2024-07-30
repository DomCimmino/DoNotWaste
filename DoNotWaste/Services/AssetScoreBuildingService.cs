using DoNotWaste.Authentication;
using DoNotWaste.Models.AssetScoreModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class AssetScoreBuildingService(IHttpClient httpClient, IAuthenticationService authenticationService)
    : IAssetScoreBuildingService
{
    public async Task<BuildingResponse> CreateSimpleBuildings(AssetScoreSimpleBuilding simpleBuildingRequest)
    {
        return await RefitExtensions.For<IAssetScoreBuildingApi>(await httpClient.GetHttpClient(false), false)
            .CreateSimpleBuildings(new SimpleBuildingRequest
            {
                Token = await authenticationService.GetAssetScoreToken(),
                AssetScoreBuilding = simpleBuildingRequest
            });
    }
    
    public async Task<List<BuildingResponse>> GetBuildings()
    {
        return await RefitExtensions.For<IAssetScoreBuildingApi>(await httpClient.GetHttpClient(false), false)
            .GetBuildings(new BaseRequest
            {
                Token = await authenticationService.GetAssetScoreToken()
            });
    }
    
    public async Task<BuildingResponse> GetBuildingById(int buildingId)
    {
        return await RefitExtensions.For<IAssetScoreBuildingApi>(await httpClient.GetHttpClient(false), false)
            .GetBuildingById(buildingId, new BaseRequest()
            {
                Token = await authenticationService.GetAssetScoreToken()
            });
    }

    public async Task<byte[]> GetReport(int buildingId)
    {
        var content = await RefitExtensions.For<IAssetScoreBuildingApi>(await httpClient.GetHttpClient(false), false)
            .GetReport(buildingId, new BaseRequest()
            {
                Token = await authenticationService.GetAssetScoreToken()
            });
        return await content.ReadAsByteArrayAsync();
    }
}