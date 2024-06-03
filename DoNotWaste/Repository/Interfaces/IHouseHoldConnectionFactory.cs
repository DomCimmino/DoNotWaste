using System.Data.SQLite;

namespace DoNotWaste.Repository.Interfaces;

public interface IHouseHoldConnectionFactory
{
    SQLiteConnection CreateConnection();
}