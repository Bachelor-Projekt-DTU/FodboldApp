using Realms;

namespace FodboldApp.Model
{
    public class LeagueTableModel : RealmObject
    {
        [Ignored]
        public int Index { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
        public string MP { get; set;}
        public string Wins { get; set; }
        public string Draws { get; set; }
        public string Losses { get; set; }
        public string W_D_L { get
            {
                return Wins +"-"+ Draws +"-"+ Losses;
            }
        }
        public string GoalsFor { get; set; }
        public string GoalsAgainst { get; set; }
        public string GoalsFA { get
            {
                return GoalsFor + "/" + GoalsAgainst;
            }
        }
        public string Points { get; set; }
        public string GroupName { get; set; }
    }
}
