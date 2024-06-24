using DoNotWaste.Models.AssetScoreModels;
using Refit;

namespace DoNotWaste.Services.API;

public interface IAssetScoreBuildingApi
{
    [Post("/simple_buildings")]
    Task<BuildingResponse> CreateSimpleBuildings([Body(BodySerializationMethod.Serialized)] SimpleBuildingRequest simpleBuildingRequest);

    [Get("/buildings/{buildingId}")]
    Task<BuildingResponse> GetBuildingById(int buildingId, [Body(BodySerializationMethod.Serialized)] BaseRequest baseRequest);

    [Get("/buildings/{buildingId}/simulations/{simulationId}")]
    Task<SimulationResponse> GetSimulation(int buildingId, int simulationId, [Body(BodySerializationMethod.Serialized)] BaseRequest baseRequest);

    [Get("/buildings/{buildingId}/report")]
    Task<HttpContent> GetReport(int buildingId, [Body(BodySerializationMethod.Serialized)] BaseRequest baseRequest);

    [Post("/buildings/{buildingId}/simulations")]
    Task<SimulationResponse> StartSimulation(int buildingId, [Body(BodySerializationMethod.Serialized)] BaseRequest baseRequest);
    
}