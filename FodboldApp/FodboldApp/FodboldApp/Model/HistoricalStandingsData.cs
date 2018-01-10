using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Data
{
    class HistoricalStandingsData
    {
        public string TournamentName { get; set; }

        public static List<HistoricalStandingsData> HistoricalStandingsDataList { get; set; } = new List<HistoricalStandingsData>();
       
            //    List<HistoricalStandingsData> clubs = new List<HistoricalStandingsData>()
            //{
            //    new HistoricalStandingsData { TournamentName = "LANDSFODBOLDTURNERINGEN" },
            //    new HistoricalStandingsData { TournamentName = "MESTERSKABSSERIEN" },
            //    new HistoricalStandingsData { TournamentName = "Kriseturneringen – kreds 3" },
            //    new HistoricalStandingsData { TournamentName = "LANDSFODBOLDTURNERINGEN" },
            //    new HistoricalStandingsData { TournamentName = "DANMARKSTURNERINGEN – 1. Division"}
            //};
    }
}
