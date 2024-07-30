using DoNotWaste.Models.AssetScoreModels;
using Refit;

namespace DoNotWaste.Services.API;

public interface IAssetScoreBuildingApi
{
    [Post("/api/v2/simple_buildings")]
    Task<BuildingResponse> CreateSimpleBuildings([Body(BodySerializationMethod.Serialized)] SimpleBuildingRequest simpleBuildingRequest);

    [Get("/rp/buildings")]
    Task<List<BuildingResponse>> GetBuildings([Body(BodySerializationMethod.Serialized)] BaseRequest baseRequest);

    [Get("/api/v2/buildings/{buildingId}")]
    Task<BuildingResponse> GetBuildingById(int buildingId, [Body(BodySerializationMethod.Serialized)] BaseRequest baseRequest);

    [Get("/api/v2/buildings/{buildingId}/simulations/{simulationId}")]
    Task<SimulationResponse> GetSimulation(int buildingId, int simulationId, [Body(BodySerializationMethod.Serialized)] BaseRequest baseRequest);

    [Get("/api/v2/buildings/{buildingId}/report")]
    Task<HttpContent> GetReport(int buildingId, [Body(BodySerializationMethod.Serialized)] BaseRequest baseRequest);

    [Post("/api/v2/buildings/{buildingId}/simulations")]
    Task<SimulationResponse> StartSimulation(int buildingId, [Body(BodySerializationMethod.Serialized)] BaseRequest baseRequest);
    
}