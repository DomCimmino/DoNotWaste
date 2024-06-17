namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot("log")]
public class EnergyStarAudit
{
    /// <summary>
    /// The username of the user who created the record. This information is only available in an XML response.
    /// </summary>
    [XmlElement("createdBy")]
    public string? CreatedBy { get; set; }

    /// <summary>
    /// The id of the user who created the record. This information is only available in an XML response.
    /// </summary>
    [XmlElement("createdByAccountId")]
    public long? CreatedByAccountId { get; set; }

    /// <summary>
    /// The date and time stamp the record was created (in EST). This information is only available in an XML response.
    /// </summary>
    [XmlElement("createdDate")]
    public DateTime? CreatedDate { get; set; }

    /// <summary>
    /// The username of the user who performed the last update. This information is only available in an XML response.
    /// </summary>
    [XmlElement("lastUpdatedBy")]
    public string? LastUpdatedBy { get; set; }

    /// <summary>
    /// The id of the user who performed the last update. This information is only available in an XML response.
    /// </summary>
    [XmlElement("lastUpdatedByAccountId")]
    public long? LastUpdatedByAccountId { get; set; }

    /// <summary>
    /// The date and time stamp of the last update (in EST). This information is only available in an XML response.
    /// </summary>
    [XmlElement("lastUpdatedDate")]
    public DateTime? LastUpdatedDate { get; set; }
}