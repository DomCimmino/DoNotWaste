namespace DoNotWaste.Models.EnergyStarModels.Enums;

public enum EnergyStarReportType
{
    [XmlEnum("CUSTOM")] Custom,
    [XmlEnum("ENERGY_STAR")] EnergyStar
}

public enum EnergyStarReportingIntervalType
{
    [XmlEnum("MONTHLY")] Monthly,
    [XmlEnum("QUARTERLY")] Quarterly,
    [XmlEnum("YEARLY")] Yearly
}

public enum EnergyStarReportStatusType
{
    [XmlEnum("INITIALIZED")] Initialized,
    [XmlEnum("SUBMITTED")] Submitted,
    [XmlEnum("IN_PROCESS")] InProcess,
    [XmlEnum("FAILED")] Failed,
    [XmlEnum("GENERATED")] Generated,
    [XmlEnum("READY_FOR_DOWNLOAD")] ReadyForDownload,
    [XmlEnum("GENERATED_WITH_ERRORS")] GeneratedWithErrors,
    [XmlEnum("SENT")] Sent
}

public enum EnergyStarDataRequestStatusType
{
    [XmlEnum("OPEN")] Open,
    [XmlEnum("CLOSED")] Closed,
    [XmlEnum("ALL")] All
}