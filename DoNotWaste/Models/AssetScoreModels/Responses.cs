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