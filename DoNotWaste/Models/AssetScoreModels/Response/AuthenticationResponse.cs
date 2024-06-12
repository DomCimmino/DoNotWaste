using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels.Response;

public class AuthenticationResponse
{
    [JsonProperty("user_id")]
    public int? UserId { get; set; }
    
    [JsonProperty("token")]
    public string? Token { get; set; }
}