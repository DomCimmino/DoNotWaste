namespace DoNotWaste.Models.DataModel;

public class BaseBuilding
{
    public int Id { get; set; }
    public DateTime FirstDateMeasure => Costant.StartDate;
    public DateTime LastDateMeasure => Costant.EndDate;

    public List<Record> MonthlyTotal()
    {
        var monthlyTotals = new Dictionary<(int Year, int Month), double>();

        foreach (var prop in GetType().GetProperties())
        {
            if (!prop.Name.Contains("Consumption") || prop.PropertyType !=
                typeof(List<Record>)) continue;

            if (prop.GetValue(this) is not List<Record> consumptionList) continue;

            foreach (var record in consumptionList)
            {
                if (!record.Value.HasValue) continue;
                var key = (record.StartDate.Year, record.EndDate.Month);
                if (!monthlyTotals.ContainsKey(key))
                {
                    monthlyTotals[key] = 0;
                }

                monthlyTotals[key] += record.Value ?? 0;
            }
        }

        var result = monthlyTotals.Select(kv =>
            {
                var (year, month) = kv.Key;
                var startDate = new DateTime(year, month, 1);
                var endDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                return new Record(startDate, endDate, kv.Value);
            })
            .ToList();

        return result;
    }
}