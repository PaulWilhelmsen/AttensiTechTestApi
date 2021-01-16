using Npgsql;

namespace Persistence.Connection.Abstract
{
    public interface IDbConnection
    {
        NpgsqlConnection CreateConnection();
    }
}