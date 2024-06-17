using DoNotWaste.Models.AssetScoreModels;
using Refit;

namespace DoNotWaste.Services.API;

public interface IAssetScoreBuildingApi
{
    [Post("/simple_buildings")]
    Task<int> CreateSimpleBuildings([Body(BodySerializationMethod.Serialized)] SimpleBuildingRequest simpleBuildingRequest);
}