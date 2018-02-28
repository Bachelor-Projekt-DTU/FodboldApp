using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    class LeagueTableModel : RealmObject
    {
        public string Position { get; set; }
        public string Team { get; set; }
        public string MP { get; set; }
        public string Wins { get; set; }
        public string Draws { get; set; }
        public string Losses { get; set; }
        public string GoalsFor { get; set; }
        public string GoalsAgainst { get; set; }
        public string Points { get; set; }
    }
}
