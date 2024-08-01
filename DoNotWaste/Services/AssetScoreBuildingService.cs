using AutoMapper;
using DoNotWaste.Authentication;
using DoNotWaste.DTO;
using DoNotWaste.Models.AssetScoreModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class AssetScoreBuildingService(IHttpClient httpClient, IAuthenticationService authenticationService, IMapper mapper)
    : IAssetScoreBuildingService
{
    private async Task<TRequest> CreateRequest<TRequest>(TRequest request) where TRequest : BaseRequest
    {
        request.Token = await authenticationService.GetAssetScoreToken();
        return request;
    }
    
    public async Task<BuildingResponse> CreateSimpleBuildings(AssetScoreSimpleBuilding simpleBuildingRequest)
    {
        return await RefitExtensions.For<IAssetScoreBuildingApi>(await httpClient.GetHttpClient(false), false)
            .CreateSimpleBuildings(await CreateRequest(new SimpleBuildingRequest
            {
                AssetScoreBuilding = simpleBuildingRequest
            }));
    }
    
    public async Task<List<BuildingDto>> GetBuildings()
    {
        var buildings =  await RefitExtensions.For<IAssetScoreBuildingApi>(await httpClient.GetHttpClient(false), false)
            .GetBuildings(await CreateRequest(new BaseRequest()));
        return buildings.Select(mapper.Map<BuildingDto>).ToList();
    }
    
    public async Task<BuildingDto> GetBuildingById(int buildingId)
    {
        var building =  await RefitExtensions.For<IAssetScoreBuildingApi>(await httpClient.GetHttpClient(false), false)
            .GetBuildingById(buildingId, await CreateRequest(new BaseRequest()));
        return mapper.Map<BuildingDto>(building);
    }

    public async Task<byte[]> GetReport(int buildingId)
    {
        var content = await RefitExtensions.For<IAssetScoreBuildingApi>(await httpClient.GetHttpClient(false), false)
            .GetReport(buildingId, await CreateRequest(new BaseRequest()));
        return await content.ReadAsByteArrayAsync();
    }

    public async Task<List<Recommendation>> GetRecommendations(int buildingId)
    {
        return await RefitExtensions.For<IAssetScoreBuildingApi>(await httpClient.GetHttpClient(false), false)
            .GetRecommendations(buildingId, await CreateRequest(new BaseRequest()));
    }
}