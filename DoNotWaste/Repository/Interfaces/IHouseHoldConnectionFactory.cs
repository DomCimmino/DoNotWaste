using Microsoft.Data.Sqlite;

namespace DoNotWaste.Repository.Interfaces;

public interface IHouseHoldConnectionFactory
{
    SqliteConnection CreateConnection();
}