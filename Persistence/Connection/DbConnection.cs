using Common.Helpers.Abstract;
using Npgsql;
using Persistence.Connection.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Connection
{
    public class DbConnection : IDbConnection
    {
        private readonly IEnvironmentHelper _environmentHelper;
        public DbConnection(IEnvironmentHelper environmentHelper)
        {
            _environmentHelper = environmentHelper ?? throw new ArgumentNullException(nameof(environmentHelper));
        }

        public NpgsqlConnection CreateConnection()
        {
            var connectionString = _environmentHelper.GetEnvironmentVariable("DbAttensiTechTest");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("Connection string to DbAttensiTechTest is not found");

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            return new NpgsqlConnection(connectionString);
        }
    }
}
