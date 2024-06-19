namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot(ElementName="internationalWeatherStationList")]
public class EnergyStarWeatherStation
{
    [XmlElement(ElementName="station")] 
    public List<Station>? Station { get; set; } 

    [XmlElement(ElementName="links")] 
    public Links? Links { get; set; } 
}

[XmlRoot(ElementName="station")]
public class Station { 

    [XmlAttribute(AttributeName="id")] 
    public int Id { get; set; } 

    [XmlAttribute(AttributeName="country")] 
    public string? Country { get; set; } 

    [XmlAttribute(AttributeName="countryName")] 
    public string? CountryName { get; set; } 

    [XmlAttribute(AttributeName="stationName")] 
    public string? StationName { get; set; } 
}