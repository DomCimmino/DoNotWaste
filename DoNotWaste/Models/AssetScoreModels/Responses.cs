using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class BaseResponse
{
    [JsonProperty("status")] 
    public string? Status { get; set; }
    
    [JsonProperty("error")] 
    public string? ErrorMessage { get; set; }
}

public class AuthenticationResponse : BaseResponse
{
    [JsonProperty("user_id")]
    public int? UserId { get; set; }
    
    [JsonProperty("token")]
    public string? Token { get; set; }
}

public class BuildingResponse
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("owner")]
    public Owner? Owner { get; set; }

    [JsonProperty("status")]
    public string? Status { get; set; }

    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonProperty("html_url")]
    public string? HtmlUrl { get; set; }
}

public class SimulationResponse
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("rating")]
    public int? Rating { get; set; }

    [JsonProperty("simulation_started_at")]
    public DateTime? SimulationStartedAt { get; set; }

    [JsonProperty("simulation_completed_at")]
    public DateTime? SimulationCompletedAt { get; set; }

    [JsonProperty("simulation_completion_type")]
    public string? SimulationCompletionType { get; set; }

    [JsonProperty("measures")]
    public List<object>? Measures { get; set; }
}