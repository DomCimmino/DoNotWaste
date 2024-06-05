using System.Data.SQLite;
using DoNotWaste.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace DoNotWaste.Repository;

public class HouseHoldConnectionFactory(IWebHostEnvironment environment, IOptions<Configuration> secrets)
    : IHouseHoldConnectionFactory
{
    private SQLiteConnection? _sqliteConnection;

    private string GetPath() =>
        "Data Source=" + Path.Combine(environment.WebRootPath, "data", secrets.Value.FileDataName ?? string.Empty) + ";Version=3";

    public SQLiteConnection CreateConnection()
    { 
        _sqliteConnection ??= new SQLiteConnection(GetPath());
        _sqliteConnection.OpenAsync();
        return _sqliteConnection;
    }
}