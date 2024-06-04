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

    protected static double LoadData(DataRowCollection rows, string columnName)
    {
        var totalConsumption = 0d;
        var previousConsumption = (double)rows[0][columnName];

        for (var i = 1; i < rows.Count; i++)
        {
            var currentConsumption = (double)rows[i][columnName];
            totalConsumption += currentConsumption - previousConsumption;
            previousConsumption = currentConsumption;
        }

        return totalConsumption;
    }
}