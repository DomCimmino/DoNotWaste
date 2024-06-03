namespace DoNotWaste.Models.DataModel;

/// <summary>
/// Energy imported from the public grid in an industrial warehouse building in kWh.
/// </summary>
public class IndustrialBuilding
{
    /// <summary>
    /// Energy imported from the public grid in an industrial warehouse building in kWh.
    /// </summary>
    public double? UrbanImportElectricityGrid { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial warehouse building in kWh.
    /// </summary>
    public double? FirstPhotovoltaicProduction { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial warehouse building in kWh.
    /// </summary>
    public double? SecondPhotovoltaicProduction { get; set; }

    /// <summary>
    /// Battery charging energy in an industrial building of a business in the crafts sector in kWh.
    /// </summary>
    public double? StorageCharge { get; set; }

    /// <summary>
    /// Energy in kWh.
    /// </summary>
    public double? StorageDecharge { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? AreaOfficesConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? FirstAreaRoomConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? SecondAreaRoomConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? ThirdAreaRoomConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? FourthAreaRoomConsumption { get; set; }

    /// <summary>
    /// Compressor energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? CompressorConsumption { get; set; }

    /// <summary>
    /// Cooling aggregate energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? CoolingAggregateConsumption { get; set; }

    /// <summary>
    /// Cooling pumps energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? CoolingPumpsConsumption { get; set; }

    /// <summary>
    /// Dishwasher energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? DishwasherConsumption { get; set; }

    /// <summary>
    /// Electric Vehicle charging energy in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? CharingEletricVehicleConsumption { get; set; }
    
    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? FirstMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? SecondMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? ThirdMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? FourthMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? FifthMachineConsumption { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? FacadePhotovoltaciProduction { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? RoofPhotovoltaciProduction { get; set; }

    /// <summary>
    /// Refrigerator energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? RefrigeratorConsumption { get; set; }

    /// <summary>
    /// Ventilation energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public double? VentilationConsumption { get; set; }
}