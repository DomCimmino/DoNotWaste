namespace DoNotWaste.Models.DataModel;

/// <summary>
/// Energy imported from the public grid in an industrial warehouse building in kWh.
/// </summary>
public class IndustrialBuilding : BaseBuilding
{
    /// <summary>
    /// Energy imported from the public grid in an industrial warehouse building in kWh.
    /// </summary>
    public List<ConsumptionRecord>? UrbanImportElectricityGrid { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial warehouse building in kWh.
    /// </summary>
    public List<ConsumptionRecord>? FirstPhotovoltaicProduction { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial warehouse building in kWh.
    /// </summary>
    public List<ConsumptionRecord>? SecondPhotovoltaicProduction { get; set; }

    /// <summary>
    /// Battery charging energy in an industrial building of a business in the crafts sector in kWh.
    /// </summary>
    public List<ConsumptionRecord>? StorageCharge { get; set; }

    /// <summary>
    /// Energy in kWh.
    /// </summary>
    public List<ConsumptionRecord>? StorageDecharge { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? AreaOfficesConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? FirstAreaRoomConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? SecondAreaRoomConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? ThirdAreaRoomConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? FourthAreaRoomConsumption { get; set; }

    /// <summary>
    /// Compressor energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? CompressorConsumption { get; set; }

    /// <summary>
    /// Cooling aggregate energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? CoolingAggregateConsumption { get; set; }

    /// <summary>
    /// Cooling pumps energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? CoolingPumpsConsumption { get; set; }

    /// <summary>
    /// Dishwasher energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? DishwasherConsumption { get; set; }

    /// <summary>
    /// Electric Vehicle charging energy in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? CharingEletricVehicleConsumption { get; set; }
    
    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? FirstMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? SecondMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? ThirdMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? FourthMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? FifthMachineConsumption { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? FacadePhotovoltaicProduction { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? RoofPhotovoltaicProduction { get; set; }

    /// <summary>
    /// Refrigerator energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? RefrigeratorConsumption { get; set; }

    /// <summary>
    /// Ventilation energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<ConsumptionRecord>? VentilationConsumption { get; set; }
}