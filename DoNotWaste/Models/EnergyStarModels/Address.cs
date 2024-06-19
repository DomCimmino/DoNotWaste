namespace DoNotWaste.Models.EnergyStarModels;

[XmlRoot(ElementName = "address")]
public class Address
{
    [XmlAttribute(AttributeName = "address1")]
    public string? Address1 { get; set; }

    [XmlAttribute(AttributeName = "city")] 
    public string? City { get; set; }

    [XmlAttribute(AttributeName = "state")]
    public string? State { get; set; }

    [XmlAttribute(AttributeName = "postalCode")]
    public string? PostalCode { get; set; }

    [XmlAttribute(AttributeName = "country")]
    public string? Country { get; set; }
}