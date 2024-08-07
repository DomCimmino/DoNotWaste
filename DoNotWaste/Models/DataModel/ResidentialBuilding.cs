namespace DoNotWaste.Models.DataModel;

/// <summary>
/// Represents the energy consumption data for various appliances and systems in residential buildings located in a suburban area in kWh.
/// </summary>
public class ResidentialBuilding : BaseBuilding
{
    /// <summary>
    /// Gets or sets the dishwasher energy consumption in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<Record>? DishwasherConsumption { get; set; }

    /// <summary>
    /// Gets or sets the freezer energy consumption in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<Record>? FreezerConsumption { get; set; }

    /// <summary>
    /// Gets or sets the energy imported from the public grid in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<Record>? UrbanImportElectricityGrid { get; set; }

    /// <summary>
    /// Gets or sets the energy exported from the residential building in a public grid, located in the suburban area in kWh.
    /// </summary>
    public List<Record>? UrbanExportElectricityGrid { get; set; }

    /// <summary>
    /// Gets or sets the heat pump energy consumption in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<Record>? HeatPumpConsumption { get; set; }

    /// <summary>
    /// Gets or sets the total photovoltaic energy generation in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<Record>? PhotovoltaicProduction { get; set; }

    /// <summary>
    /// Gets or sets the washing machine energy consumption in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<Record>? WashingMachineConsumption { get; set; }

    /// <summary>
    /// Gets or sets the circulation pump energy consumption in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<Record>? CirculationPumpConsumption { get; set; }

    /// <summary>
    /// Gets or sets the refrigerator energy consumption in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<Record>? RefrigeratorConsumption { get; set; }

    /// <summary>
    /// Electric Vehicle charging energy in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<Record>? CharingEletricVehicleConsumption { get; set; }
}