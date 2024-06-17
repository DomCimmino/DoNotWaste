namespace DoNotWaste.Models.DataModel;

/// <summary>
/// Energy imported from the public grid in an industrial warehouse building in kWh.
/// </summary>
public class IndustrialBuilding : BaseBuilding
{
    /// <summary>
    /// Energy imported from the public grid in an industrial warehouse building in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? UrbanImportElectricityGrid { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial warehouse building in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? FirstPhotovoltaicProduction { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial warehouse building in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? SecondPhotovoltaicProduction { get; set; }

    /// <summary>
    /// Battery charging energy in an industrial building of a business in the crafts sector in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? StorageCharge { get; set; }

    /// <summary>
    /// Energy in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? StorageDecharge { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? AreaOfficesConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? FirstAreaRoomConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? SecondAreaRoomConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? ThirdAreaRoomConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an area, consisting of several smaller loads, in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? FourthAreaRoomConsumption { get; set; }

    /// <summary>
    /// Compressor energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? CompressorConsumption { get; set; }

    /// <summary>
    /// Cooling aggregate energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? CoolingAggregateConsumption { get; set; }

    /// <summary>
    /// Cooling pumps energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? CoolingPumpsConsumption { get; set; }

    /// <summary>
    /// Dishwasher energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? DishwasherConsumption { get; set; }

    /// <summary>
    /// Electric Vehicle charging energy in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? CharingEletricVehicleConsumption { get; set; }
    
    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? FirstMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? SecondMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? ThirdMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? FourthMachineConsumption { get; set; }

    /// <summary>
    /// Energy consumption of an industrial- or research-machine in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? FifthMachineConsumption { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? FacadePhotovoltaicProduction { get; set; }

    /// <summary>
    /// Total Photovoltaic energy generation in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? RoofPhotovoltaicProduction { get; set; }

    /// <summary>
    /// Refrigerator energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? RefrigeratorConsumption { get; set; }

    /// <summary>
    /// Ventilation energy consumption in an industrial building, part of a research institute in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? VentilationConsumption { get; set; }
}