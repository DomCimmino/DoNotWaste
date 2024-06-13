namespace DoNotWaste.Models.EnergyStarModels.Enums;

/// <summary>
/// The units that measure the energy for the meter (Kbtu, KWh, Mbtu, MWh, ccf, gallons, etc.).
/// </summary>
public enum EnergyStarUnitOfMeasure
{
    [XmlEnum("ccf (hundred cubic feet)")] CcfHundredCubicFeet,
    [XmlEnum("cf (cubic feet)")] CfCubicFeet,
    [XmlEnum("cGal (hundred gallons) (UK)")] CGalHundredGallonsUK,
    [XmlEnum("cGal (hundred gallons) (US)")] CGalHundredGallonsUS,
    [XmlEnum("Cubic Meters per Day")] CubicMetersPerDay,
    [XmlEnum("cm (Cubic meters)")] CmCubicMeters,
    [XmlEnum("Cords")] Cords,
    [XmlEnum("Gallons (UK)")] GallonsUK,
    [XmlEnum("Gallons (US)")] GallonsUS,
    [XmlEnum("GJ")] GJ,
    [XmlEnum("kBtu (thousand Btu)")] KBtuThousandBtu,
    [XmlEnum("kcf (thousand cubic feet)")] KcfThousandCubicFeet,
    [XmlEnum("Kcm (Thousand Cubic meters)")] KcmThousandCubicMeters,
    [XmlEnum("KGal (thousand gallons) (UK)")] KGalThousandGallonsUK,
    [XmlEnum("KGal (thousand gallons) (US)")] KGalThousandGallonsUS,
    [XmlEnum("Kilogram")] Kilogram,
    [XmlEnum("KLbs. (thousand pounds)")] KLbsThousandPounds,
    [XmlEnum("kWh (thousand Watt-hours)")] KWhThousandWattHours,
    [XmlEnum("Liters")] Liters,
    [XmlEnum("MBtu (million Btu)")] MBtuMillionBtu,
    [XmlEnum("MCF(million cubic feet)")] MCFMillionCubicFeet,
    [XmlEnum("mg/l (milligrams per liter)")] MgPerLiter,
    [XmlEnum("MGal (million gallons) (UK)")] MGalMillionGallonsUK,
    [XmlEnum("MGal (million gallons) (US)")] MGalMillionGallonsUS,
    [XmlEnum("Million Gallons per Day")] MillionGallonsPerDay,
    [XmlEnum("MLbs. (million pounds)")] MLbsMillionPounds,
    [XmlEnum("MWh (million Watt-hours)")] MWhMillionWattHours,
    [XmlEnum("pounds")] Pounds,
    [XmlEnum("Pounds per year")] PoundsPerYear,
    [XmlEnum("therms")] Therms,
    [XmlEnum("ton hours")] TonHours,
    [XmlEnum("Tonnes (metric)")] TonnesMetric,
    [XmlEnum("tons")] Tons
}