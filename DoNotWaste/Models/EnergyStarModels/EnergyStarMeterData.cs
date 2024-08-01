namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot(ElementName = "meterData")]
public class EnergyStarMeterData
{
    [XmlElement(ElementName = "meterConsumption")]
    public List<MeterConsumptionBase>? MeterConsumptions { get; set; }

    [XmlElement(ElementName = "links")]
    public Links? Links { get; set; }
}

public class MeterConsumptionBase
{
    [XmlElement(ElementName = "startDate")]
    public string? StartDate { get; set; }

    [XmlElement(ElementName = "endDate")]
    public string? EndDate { get; set; }
    
    [XmlElement(ElementName = "cost")]
    public double? Cost { get; set; }
    
    [XmlElement(ElementName = "usage")]
    public double? Usage { get; set; }
}

public class MeterConsumption : MeterConsumptionBase
{
    [XmlElement(ElementName = "id")]
    public int? Id { get; set; }

    [XmlElement(ElementName = "RECOwnership")]
    public string? RecOwnership { get; set; }
    
    [XmlElement(ElementName = "energyExportedOffSite")]
    public double? EnergyExportedOffSite { get; set; }

    [XmlElement(ElementName = "audit")]
    public EnergyStarAudit? Audit { get; set; }

    [XmlAttribute(AttributeName = "estimatedValue")]
    public bool EstimatedValue { get; set; }

    [XmlAttribute(AttributeName = "isGreenPower")]
    public bool IsGreenPower { get; set; }
    
    [XmlElement(ElementName = "greenPower")]
    public GreenPower? GreenPower { get; set; }
}

public class GreenPower
{
    [XmlElement(ElementName = "value")]
    public double? Value { get; set; }

    [XmlElement(ElementName = "sources")]
    public GreenPowerSources? Sources { get; set; }

    [XmlElement(ElementName = "generationLocation")]
    public GenerationLocation? GenerationLocation { get; set; }
}

public class GreenPowerSources
{
    [XmlElement(ElementName = "biomassPct")]
    public double? BiomassPct { get; set; }

    [XmlElement(ElementName = "biogasPct")]
    public double? BiogasPct { get; set; }

    [XmlElement(ElementName = "geothermalPct")]
    public double? GeothermalPct { get; set; }

    [XmlElement(ElementName = "smallHydroPct")]
    public double? SmallHydroPct { get; set; }

    [XmlElement(ElementName = "solarPct")]
    public double? SolarPct { get; set; }

    [XmlElement(ElementName = "windPct")]
    public double? WindPct { get; set; }

    [XmlElement(ElementName = "unknownPct")]
    public double? UnknownPct { get; set; }
}

public class GenerationLocation
{
    [XmlElement(ElementName = "generationPlant")]
    public double? GenerationPlant { get; set; }

    [XmlElement(ElementName = "eGridSubRegion")]
    public string? EGridSubRegion { get; set; }

    [XmlElement(ElementName = "unknown")]
    public string? Unknown { get; set; }
}