namespace DoNotWaste.Models.DataModel;

/// <summary>
/// Energy imported from the public grid in an industrial warehouse building in kWh.
/// </summary>
public class IndustrialBuilding : BaseBuilding
{
    /// <summary>
    /// Energy imported from the public grid in an industrial warehouse building in kWh.
    /// </summary>
    public List<Record>? UrbanImportElectricityGrid { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial warehouse building in kWh.
    /// </summary>
    public List<Record>? FirstPhotovoltaicProduction { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial warehouse building in kWh.
    /// </summary>
    public List<Record>? SecondPhotovoltaicProduction { get; set; }

    /// <summary>
    /// Battery charging energy in an industrial building of a business in the crafts sector in kWh.
    /// </summary>
    public List<Record>? StorageCharge { get; set; }

    /// <summary>
    /// Energy in kWh.
    /// </summary>
    public List<Record>? StorageDecharge { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? AreaOfficesConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? FirstAreaRoomConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? SecondAreaRoomConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? ThirdAreaRoomConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? FourthAreaRoomConsumption { get; set; }

    /// <summary>
    /// Compressor energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? CompressorConsumption { get; set; }

    /// <summary>
    /// Cooling aggregate energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? CoolingAggregateConsumption { get; set; }

    /// <summary>
    /// Cooling pumps energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? CoolingPumpsConsumption { get; set; }

    /// <summary>
    /// Dishwasher energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? DishwasherConsumption { get; set; }

    /// <summary>
    /// Electric Vehicle charging energy in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? CharingEletricVehicleConsumption { get; set; }
    
    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? FirstMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? SecondMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? ThirdMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? FourthMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? FifthMachineConsumption { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? FacadePhotovoltaicProduction { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? RoofPhotovoltaicProduction { get; set; }

    /// <summary>
    /// Refrigerator energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? RefrigeratorConsumption { get; set; }

    /// <summary>
    /// Ventilation energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<Record>? VentilationConsumption { get; set; }
}