using System.Data;
using System.Data.SQLite;
using DoNotWaste.Repository.Interfaces;

namespace DoNotWaste.Repository;

public class BaseRepository(IHouseHoldConnectionFactory factory)
{
    protected readonly SQLiteConnection Connection = factory.CreateConnection();

    protected DataTable DoQuery(string query)
    {
        using var command = new SQLiteCommand(query, Connection);
        using var adapter = new SQLiteDataAdapter(command);
        var dataTable = new DataTable();
        adapter.Fill(dataTable);
        return dataTable;
    }

    protected static List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)> GetMonthlyConsumption(
        DataRowCollection rows, string consumptionColumnName)
    {
        if (rows == null || rows.Count == 0)
        {
            throw new ArgumentException("The DataRowCollection is null or empty.");
        }

        if (!rows[0].Table.Columns.Contains(consumptionColumnName))
        {
            throw new ArgumentException($"Column '{consumptionColumnName}' does not exist.");
        }

        var monthlyConsumption = new List<(DateTime StartDate, DateTime EndDate, double? TotalConsumption)>();

        // Group rows by month and year
        var groupedByMonth = rows.Cast<DataRow>()
            .GroupBy(row => new
            {
                DateTime.Parse((string)row[0]).Year,
                DateTime.Parse((string)row[0]).Month
            });

        foreach (var group in groupedByMonth)
        {
            var startDate = group.First();
            var endDate = group.Last();

            
            var startConsumption = startDate[consumptionColumnName] != DBNull.Value ? Convert.ToDouble(startDate[consumptionColumnName]) : 0d;
            var endConsumption = endDate[consumptionColumnName] != DBNull.Value ? Convert.ToDouble(endDate[consumptionColumnName]) : startConsumption;
            var totalConsumption = endConsumption - startConsumption;

            var startDateTime = DateTime.Parse((string)startDate[0]);
            var endDateTime = DateTime.Parse((string)endDate[0]);

            var startOfMonth = new DateTime(startDateTime.Year, startDateTime.Month, 1);
            var endOfMonth = new DateTime(endDateTime.Year, endDateTime.Month,
                DateTime.DaysInMonth(endDateTime.Year, endDateTime.Month));

            monthlyConsumption.Add((startOfMonth, endOfMonth, totalConsumption));
        }

        return monthlyConsumption;
    }
}