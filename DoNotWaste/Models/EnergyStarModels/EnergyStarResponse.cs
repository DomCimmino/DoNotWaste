namespace DoNotWaste.Models.EnergyStarModels;

/// <summary>
/// Represents the response of the operation.
/// </summary>
[XmlRoot(ElementName = "response")]
public class EnergyStarResponse
{
    /// <summary>
    /// The id of the entity that you are trying to add or update.
    /// </summary>
    [XmlElement(ElementName = "id")]
    public int? Id { get; set; }

    /// <summary>
    /// Contains the links related to the response.
    /// </summary>
    [XmlElement(ElementName = "links")]
    public Links? Links { get; set; }

    /// <summary>
    /// The status of the web service call. Either Ok or Error.
    /// </summary>
    [XmlAttribute(AttributeName = "status")]
    public StatusType Status { get; set; }
}

/// <summary>
/// Represents a collection of links.
/// </summary>
[XmlRoot(ElementName="links")]
public class Links
{
    /// <summary>
    /// A list of links related to the response.
    /// </summary>
    [XmlElement(ElementName = "link")]
    public List<Link>? Link { get; set; }
}

/// <summary>
/// Represents a single link.
/// </summary>
[XmlRoot(ElementName="link")]
public class Link
{
    /// <summary>
    /// Indicates the unique Portfolio Manager identifier used to define this entity.
    /// </summary>
    [XmlAttribute(AttributeName = "id")]
    public int Id { get; set; }

    /// <summary>
    /// The description of the link.
    /// </summary>
    [XmlAttribute(AttributeName = "linkDescription")]
    public string? LinkDescription { get; set; }

    /// <summary>
    /// The URL to a web service call for subsequent processing.
    /// </summary>
    [XmlAttribute(AttributeName = "link")]
    public string? Url { get; set; }

    /// <summary>
    /// The HTTP method to the web service call.
    /// </summary>
    [XmlAttribute(AttributeName = "httpMethod")]
    public string? HttpMethod { get; set; }

    /// <summary>
    /// A brief description of the information returned from the link.
    /// </summary>
    [XmlAttribute(AttributeName = "hint")]
    public string? Hint { get; set; }
}

/// <summary>
/// Represents the status of the web service call.
/// </summary>
[XmlRoot(ElementName = "status")]
public enum StatusType
{
    [XmlEnum("Ok")]Ok,
    [XmlEnum("Error")] Error
}
