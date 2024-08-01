using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class BaseRequest
{
    [JsonProperty("token")] 
    public string? Token { get; set; }
}

public class AuthenticationRequest
{
    [JsonProperty("email")]
    public string? Email { get; set; }
    
    [JsonProperty("password")]
    public string? Password { get; set; }
    
    [JsonProperty("organization_token")]
    public string? OrganizationToken { get; set; }
}

public class SimpleBuildingRequest : BaseRequest
{
    [JsonProperty("simple_building")] 
    public AssetScoreSimpleBuilding? AssetScoreBuilding { get; set; }
}