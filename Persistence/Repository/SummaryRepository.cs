using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Common.Dto;
using Persistence.Model;
using System.Threading.Tasks;
using Persistence.Connection.Abstract;
using Dapper;
using Persistence.Repository.Abstract;
using System.Linq;

namespace Persistence.Repository
{
    public class SummaryRepository : ISummaryRepository
    {
        private readonly IDbConnection _dbConnection;
        public SummaryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }
        public async Task<List<WeeklySummaryModel>> WeeklyReportOnWeekNumberAsync(DateTime startDate, DateTime endDate)
        {
            var query = @"SELECT player.name, SUM(score) as TotalScore, SUM(time_spent) as TotalTimeSpent
                          FROM public.player_records
                          JOIN player ON player.id = player_records.player_id
                          WHERE player_records.start_date 
                          	BETWEEN @StartDate
                          	AND @EndDate
                          GROUP BY player.name
                          ORDER BY TotalScore DESC, totalTimespent DESC
                          LIMIT 10";

            using (var conn = _dbConnection.CreateConnection())
            {
                var weeklySummary = await conn.QueryAsync<WeeklySummaryModel>(query, new { StartDate = startDate, EndDate = endDate });
                return weeklySummary.ToList();
            }
        }

        //public async Task<IEnumerable<ImpactReportModel>>

        //Not working sql
        //SELECT player.name, MAX(score) AS MaxScore,
        //(SELECT score FROM
        //MIN(player_records.id) as firstScore, player_records
        //WHERE player_records.id = firstScore) as FirstTime
        //FROM player_records
        //INNER JOIN player ON player.id = player_id
        //GROUP BY player.name

        //---------------------------
        // Create an “Impact Report”
        //o The difference between the first and highest scores for all players(show the number of playthroughs and total time played).

        //hente første score på en spiller. laveste id på player_records mot høyeste score på player id.
        //SUM(playerid) for alle playthroughs
        //SUM(playtime) for total tid
    }
}
