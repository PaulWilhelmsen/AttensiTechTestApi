
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
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IDbConnection _dbConnection;

        public PlayerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException($"DI failen on {nameof(dbConnection)} in class {nameof(PlayerRepository)}");
        }

        public async Task<PlayerModel> GetPlayerById(int id)
        {
            string sql = "SELECT * FROM public.player WHERE id = @Id";

            using(var conn = CreateConnection())
            {
                var player = await conn.QueryFirstAsync<PlayerModel>(sql, new { Id = id });
                return player;
            }
        }

        //create player with name
        public async Task<int> CreateNewPlayerAsync(CreatePlayerDto newPlayer)
        {
            string query = @"INSERT INTO public.player(name)
                             VALUES (@name); 
                             SELECT currval(pg_get_serial_sequence('player','id'));";

            using (var conn = CreateConnection())
            {
                var newPlayerId = await conn.QueryFirstAsync<int>(query, new { name = newPlayer.Name });

                return newPlayerId;
            }
        }

        private NpgsqlConnection CreateConnection()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            return _dbConnection.CreateConnection();
        }
    }
}
