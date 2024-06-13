namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot("report")]
public class EnergyStarReport
{
    [XmlElement(ElementName = "timeframe")]
    public EnergyStarTimeframe? Timeframe { get; set; }

    [XmlElement(ElementName = "properties")]
    public Properties? Properties { get; set; }
}

[XmlRoot("properties")]
public class Properties
{
    [XmlElement(ElementName = "id")] 
    public List<int>? Ids { get; set; }
}