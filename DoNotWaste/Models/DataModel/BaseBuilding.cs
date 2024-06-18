namespace DoNotWaste.Models.DataModel;

public class BaseBuilding
{
    public int Id { get; set; }
    public DateTime FirstDateMeasure => Costant.StartDate;
    public DateTime LastDateMeasure => Costant.EndDate;
    
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