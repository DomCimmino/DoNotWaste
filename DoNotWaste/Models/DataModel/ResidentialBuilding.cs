namespace DoNotWaste.Models.DataModel;

/// <summary>
/// Represents the energy consumption data for various appliances and systems in residential buildings located in a suburban area in kWh.
/// </summary>
public class ResidentialBuilding : BaseBuilding
{
    /// <summary>
    /// Gets or sets the dishwasher energy consumption in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? DishwasherConsumption { get; set; }

    /// <summary>
    /// Gets or sets the freezer energy consumption in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? FreezerConsumption { get; set; }

    /// <summary>
    /// Gets or sets the energy imported from the public grid in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? UrbanImportElectricityGrid { get; set; }

    /// <summary>
    /// Gets or sets the energy exported from the residential building in a public grid, located in the suburban area in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? UrbanExportElectricityGrid { get; set; }

    /// <summary>
    /// Gets or sets the heat pump energy consumption in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? HeatPumpConsumption { get; set; }

    /// <summary>
    /// Gets or sets the total photovoltaic energy generation in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? PhotovoltaicProduction { get; set; }

    /// <summary>
    /// Gets or sets the washing machine energy consumption in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? WashingMachineConsumption { get; set; }

    /// <summary>
    /// Gets or sets the circulation pump energy consumption in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? CirculationPumpConsumption { get; set; }

    /// <summary>
    /// Gets or sets the refrigerator energy consumption in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? RefrigeratorConsumption { get; set; }

    /// <summary>
    /// Electric Vehicle charging energy in a residential building, located in the suburban area in kWh.
    /// </summary>
    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>? CharingEletricVehicleConsumption { get; set; }

    public List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)> MonthlyTotal()
    {
        var monthlyTotals = new Dictionary<(int Year, int Month), double>();
        
        foreach (var prop in GetType().GetProperties())
        {
            if (!prop.Name.Contains("Consumption") || prop.PropertyType !=
                typeof(List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>)) continue;
            
            if (prop.GetValue(this) is not List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)> consumptionList) continue;
           
            foreach (var (startDate, endDate, totalConsumption) in consumptionList)
            {
                if (!totalConsumption.HasValue) continue;
                var key = (startDate.Year, startDate.Month);
                if (!monthlyTotals.ContainsKey(key))
                {
                    monthlyTotals[key] = 0;
                }
                monthlyTotals[key] += totalConsumption.Value;
            }
        }
        
        var result = monthlyTotals.Select(kv =>
            {
                var (year, month) = kv.Key;
                var startDate = new DateTime(year, month, 1);
                var endDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                return (StartDate: startDate, EndDate: endDate, TotalConsumption: (double?)kv.Value);
            })
            .ToList();

        return result;
    }
}