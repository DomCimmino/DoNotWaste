using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels.Request;

public class AuthenticationRequest
{
    [JsonProperty("email")]
    public string? Email { get; set; }
    
    [JsonProperty("password")]
    public string? Password { get; set; }
    
    [JsonProperty("organization_token")]
    public string? OrganizationToken { get; set; }
}