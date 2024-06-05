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
        var totalConsumption = (double)rows[^1][columnName] - (double)rows[0][columnName];
        return totalConsumption;
    }
}