using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repository
{
    class SummaryRepository
    {
        //  Create a “Weekly Summary” API endpoint returning stats for a given week number(weeks start
        //on Monday):
        //o Top 10 players by score and duration.
        //SELECT TOP 10 playername, score, duration
        //WHERE ()
        //ORDER BY score, duration. Finne ut hvordan det funker i postgres


        //---------------------------
        // Create an “Impact Report”
        //o The difference between the first and highest scores for all players(show the number of playthroughs and total time played).

        //hente første score på en spiller. laveste id på player_records mot høyeste score på player id.
        //SUM(playerid) for alle playthroughs
        //SUM(playtime) for total tid
    }
}
