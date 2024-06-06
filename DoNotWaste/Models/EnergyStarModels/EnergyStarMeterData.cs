namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot(ElementName = "meterData")]
public class EnergyStarMeterData
{
    [XmlElement(ElementName = "meterConsumption")]
    public List<MeterConsumption>? MeterConsumptions { get; set; }

    [XmlElement(ElementName = "links")]
    public Links? Links { get; set; }
}

public class MeterConsumption
{
    [XmlElement(ElementName = "id")]
    public long? Id { get; set; }

    [XmlElement(ElementName = "startDate")]
    public DateTime? StartDate { get; set; }

    [XmlElement(ElementName = "endDate")]
    public DateTime? EndDate { get; set; }

    [XmlElement(ElementName = "usage")]
    public decimal? Usage { get; set; }

    [XmlElement(ElementName = "cost")]
    public decimal? Cost { get; set; }

    [XmlElement(ElementName = "energyExportedOffSite")]
    public decimal? EnergyExportedOffSite { get; set; }

    [XmlElement(ElementName = "greenPower")]
    public GreenPower? GreenPower { get; set; }

    [XmlElement(ElementName = "audit")]
    public EnergyStarAudit? Audit { get; set; }

    [XmlAttribute(AttributeName = "estimatedValue")]
    public bool? EstimatedValue { get; set; }

    [XmlAttribute(AttributeName = "isGreenPower")]
    public bool? IsGreenPower { get; set; }
}

public class GreenPower
{
    [XmlElement(ElementName = "value")]
    public decimal? Value { get; set; }

    [XmlElement(ElementName = "sources")]
    public GreenPowerSources? Sources { get; set; }

    [XmlElement(ElementName = "generationLocation")]
    public GenerationLocation? GenerationLocation { get; set; }
}

public class GreenPowerSources
{
    [XmlElement(ElementName = "biomassPct")]
    public decimal? BiomassPct { get; set; }

    [XmlElement(ElementName = "biogasPct")]
    public decimal? BiogasPct { get; set; }

    [XmlElement(ElementName = "geothermalPct")]
    public decimal? GeothermalPct { get; set; }

    [XmlElement(ElementName = "smallHydroPct")]
    public decimal? SmallHydroPct { get; set; }

    [XmlElement(ElementName = "solarPct")]
    public decimal? SolarPct { get; set; }

    [XmlElement(ElementName = "windPct")]
    public decimal? WindPct { get; set; }

    [XmlElement(ElementName = "unknownPct")]
    public decimal? UnknownPct { get; set; }
}

public class GenerationLocation
{
    [XmlElement(ElementName = "generationPlant")]
    public int? GenerationPlant { get; set; }

    [XmlElement(ElementName = "eGridSubRegion")]
    public string? EGridSubRegion { get; set; }

    [XmlElement(ElementName = "unknown")]
    public string? Unknown { get; set; }
}