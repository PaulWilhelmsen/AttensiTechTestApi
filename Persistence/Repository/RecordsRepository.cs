using Common.Dto;
using Dapper;
using Npgsql;
using Persistence.Connection.Abstract;
using Persistence.Model;
using Persistence.Repository.Abstract;
using System;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RecordsRepository : IRecordsRepository
    {
        private readonly IDbConnection _dbConnection;
        public RecordsRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        //create new record
        public async Task<int> CreateNewPlayerRecord(CreatePlayerRecordDto newRecord)
        {
            string query = @"INSERT INTO public.player_records(player_id, start_date, score, time_spent)
                             VALUES (@PlayerId, @StartDate, @Score, @TimeSpent);; 
                             SELECT currval(pg_get_serial_sequence('player_records','id'));";

            using (var conn = CreateConnection())
            {
                var newPlayerRecordId = await conn.QueryFirstAsync<int>(query, newRecord);
                return newPlayerRecordId;
            }
        }

        public async Task<PlayerRecordModel> GetPlayerRecordById(int id)
        {
            string sql = "SELECT * FROM public.player_records WHERE id = @Id";

            using (var conn = CreateConnection())
            {
                var playerRecord = await conn.QueryFirstAsync<PlayerRecordModel>(sql, new { Id = id });
                return playerRecord;
            }
        }

        //get records on player

        private NpgsqlConnection CreateConnection()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            return _dbConnection.CreateConnection();
        }
    }
}
