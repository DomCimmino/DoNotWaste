using DoNotWaste.Models.EnergyStarModels.Enums;

namespace DoNotWaste.Models.EnergyStarModels;

/// <summary>
/// Represents the status definition of a report.
/// </summary>
[XmlRoot(ElementName = "reportStatus")]
public class EnergyStarReportStatus
{
    /// <summary>
    /// The status of the report.
    /// </summary>
    [XmlElement("status")]
    public EnergyStarReportStatusType Status { get; set; }

    /// <summary>
    /// This field is not currently being used.
    /// </summary>
    [XmlElement("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The date and timestamp of when the report generation started (in EST).
    /// </summary>
    [XmlElement("generationStartDate")]
    public DateTime? GenerationStartDate { get; set; }

    /// <summary>
    /// The date and timestamp of when the report generation completed (in EST).
    /// </summary>
    [XmlElement("generationEndDate")]
    public DateTime? GenerationEndDate { get; set; }

    /// <summary>
    /// The date and timestamp of when the report was submitted to be generated (in EST).
    /// </summary>
    [XmlElement("submittedDate")]
    public DateTime? SubmittedDate { get; set; }
}