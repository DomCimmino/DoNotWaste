namespace DoNotWaste.Models;

/// <summary>
/// Represents the response of the operation.
/// </summary>
[XmlRoot(ElementName = "response")]
public class Response
{
    /// <summary>
    /// The id of the entity that you are trying to add or update.
    /// </summary>
    [XmlElement(ElementName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// Contains the links related to the response.
    /// </summary>
    [XmlElement(ElementName = "links")]
    public LinksType? Links { get; set; }

    /// <summary>
    /// A list of errors that caused this request to fail.
    /// </summary>
    [XmlElement(ElementName = "errors")]
    public ErrorsType? Errors { get; set; }

    /// <summary>
    /// A list of warnings related to the response.
    /// </summary>
    [XmlElement(ElementName = "warnings")]
    public WarningsType? Warnings { get; set; }

    /// <summary>
    /// The status of the web service call. Either Ok or Error.
    /// </summary>
    [XmlAttribute(AttributeName = "status")]
    public string? Status { get; set; }
}

/// <summary>
/// Represents a collection of links.
/// </summary>
public class LinksType
{
    /// <summary>
    /// A list of links related to the response.
    /// </summary>
    [XmlElement(ElementName = "link")]
    public List<LinkType>? Links { get; set; }
}

/// <summary>
/// Represents a single link.
/// </summary>
public class LinkType
{
    /// <summary>
    /// Indicates the unique Portfolio Manager identifier used to define this entity.
    /// </summary>
    [XmlAttribute(AttributeName = "id")]
    public long? Id { get; set; }

    /// <summary>
    /// The description of the link.
    /// </summary>
    [XmlAttribute(AttributeName = "linkDescription")]
    public string? LinkDescription { get; set; }

    /// <summary>
    /// The URL to a web service call for subsequent processing.
    /// </summary>
    [XmlAttribute(AttributeName = "link")]
    public string? Link { get; set; }

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
/// Represents a collection of errors.
/// </summary>
public class ErrorsType
{
    /// <summary>
    /// A list of errors that caused this request to fail.
    /// </summary>
    [XmlElement(ElementName = "error")]
    public List<ErrorType>? Errors { get; set; }
}

/// <summary>
/// Represents a single error.
/// </summary>
public class ErrorType
{
    /// <summary>
    /// The number of the error.
    /// </summary>
    [XmlAttribute(AttributeName = "errorNumber")]
    public string? ErrorNumber { get; set; }

    /// <summary>
    /// The description of the error.
    /// </summary>
    [XmlAttribute(AttributeName = "errorDescription")]
    public string? ErrorDescription { get; set; }
}

/// <summary>
/// Represents a collection of warnings.
/// </summary>
public class WarningsType
{
    /// <summary>
    /// A list of warnings related to the response.
    /// </summary>
    [XmlElement(ElementName = "warning")]
    public List<WarningType>? Warnings { get; set; }
}

/// <summary>
/// Represents a single warning.
/// </summary>
public class WarningType
{
    /// <summary>
    /// The number of the warning.
    /// </summary>
    [XmlAttribute(AttributeName = "warningNumber")]
    public string? WarningNumber { get; set; }

    /// <summary>
    /// The description of the warning.
    /// </summary>
    [XmlAttribute(AttributeName = "warningDescription")]
    public string? WarningDescription { get; set; }
}

/// <summary>
/// Represents the status of the web service call.
/// </summary>
public class StatusType
{
    /// <summary>
    /// The status indicating success.
    /// </summary>
    public const string Ok = "Ok";

    /// <summary>
    /// The status indicating an error.
    /// </summary>
    public const string Error = "Error";
}
