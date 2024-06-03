using DoNotWaste.Repository.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;

namespace DoNotWaste.Repository;

public class HouseHoldConnectionFactory(IWebHostEnvironment environment, IOptions<Configuration> secrets)
    : IHouseHoldConnectionFactory
{
    private readonly string? _connectionString =
        Path.Combine(environment.WebRootPath, secrets.Value.FileDataName ?? string.Empty);

    private SqliteConnection? _sqliteConnection;

    public SqliteConnection CreateConnection()
    {
        return _sqliteConnection ??= new SqliteConnection(_connectionString);
    }
}