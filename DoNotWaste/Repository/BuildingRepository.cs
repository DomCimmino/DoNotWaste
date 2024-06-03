using System.Data;
using System.Data.SQLite;
using DoNotWaste.Models.DataModel;
using DoNotWaste.Repository.Interfaces;

namespace DoNotWaste.Repository;

public class BuildingRepository(IHouseHoldConnectionFactory factory) : IBuildingRepository
{
    private readonly SQLiteConnection _connection = factory.CreateConnection();

    public ResidentialBuilding GetResidential(int residentialNumber)
    {
        var query =
            $"""
             SELECT
                 DE_KN_residential{residentialNumber}_dishwasher,
                 DE_KN_residential{residentialNumber}_freezer,
                 DE_KN_residential{residentialNumber}_grid_import,
                 DE_KN_residential{residentialNumber}_heat_pump,
                 DE_KN_residential{residentialNumber}_pv,
                 DE_KN_residential{residentialNumber}_washing_machine
             FROM
                 household_data_60min_singleindex
             WHERE
                 DE_KN_residential{residentialNumber}_dishwasher IS NOT NULL AND
                 DE_KN_residential{residentialNumber}_freezer IS NOT NULL AND
                 DE_KN_residential{residentialNumber}_grid_import IS NOT NULL AND
                 DE_KN_residential{residentialNumber}_heat_pump IS NOT NULL AND
                 DE_KN_residential{residentialNumber}_pv IS NOT NULL AND
                 DE_KN_residential{residentialNumber}_washing_machine IS NOT NULL AND
                 utc_timestamp BETWEEN '2016-05-01T00:00:00Z' AND '2017-05-01T00:00:00Z'
             """;
        using var command = new SQLiteCommand(query, _connection);
        using var adapter = new SQLiteDataAdapter(command);
        var dataTable = new DataTable();
        adapter.Fill(dataTable);
        return new ResidentialBuilding()
        {
            DishwasherConsumption = LoadConsumption(dataTable.Rows, $"DE_KN_residential{residentialNumber}_dishwasher"),
            FreezerConsumption = LoadConsumption(dataTable.Rows, $"DE_KN_residential{residentialNumber}_freezer"),
            UrbanImportElectricityGrid = LoadConsumption(dataTable.Rows, $"DE_KN_residential{residentialNumber}_grid_import"),
            HeatPumpConsumption = LoadConsumption(dataTable.Rows, $"DE_KN_residential{residentialNumber}_heat_pump"),
            WashingMachineConsumption = LoadConsumption(dataTable.Rows, $"DE_KN_residential{residentialNumber}_washing_machine"),
            PhotovoltaicProduction = LoadConsumption(dataTable.Rows, $"DE_KN_residential{residentialNumber}_pv")
        };
    }

    private static double LoadConsumption(DataRowCollection rows, string columnName)
    {
        var totalConsumption = 0d;
        for (var i = 1; i < rows.Count; i++)
        {
            var previousConsumption = (double)rows[i-1][columnName];
            var consumption = (double)rows[i][columnName];
            var difference = consumption - previousConsumption;
            totalConsumption += difference;
        }
        return totalConsumption;
    }
}