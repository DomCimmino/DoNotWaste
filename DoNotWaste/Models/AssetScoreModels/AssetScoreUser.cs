using Newtonsoft.Json;

namespace DoNotWaste.Models.AssetScoreModels;

public class AssetScoreUser
{
    /// <summary>
    /// The unique identifier for this user, used in get and update requests.
    /// </summary>
    [JsonProperty("id")]
    public int? Id { get; set; }

    /// <summary>
    /// Email address used for login, resetting passwords, and contacting the user
    /// with simulation results.
    /// </summary>
    [JsonProperty("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Unique identifier for the organization this user belongs to.
    /// </summary>
    [JsonProperty("organization_id")]
    public int? OrganizationId { get; set; }

    /// <summary>
    /// Date and time the user account was created in the Energy Asset Score application.
    /// </summary>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Date and time the user account was updated in the Energy Asset Score application.
    /// </summary>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}

public class Owner : AssetScoreUser
{
    [JsonProperty("first_name")]
    public string? FirstName { get; set; }

    [JsonProperty("last_name")]
    public string? LastName { get; set; }

    [JsonProperty("organization")]
    public Organization? Organization { get; set; }

    [JsonProperty("site_admin")]
    public bool? SiteAdmin { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }
}

public class Organization
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }
}