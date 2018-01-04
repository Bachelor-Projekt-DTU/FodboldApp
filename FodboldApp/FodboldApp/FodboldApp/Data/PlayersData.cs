using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Data
{
    class PlayersData
    {
        public static readonly int ATTRIBUTE_COUNT = 6;
        public string ImageURL { get; set; }
        public int Matches { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int MVP { get; set; }
        public int Clean_Sheet { get; set; }
        public string Name { get; set; }
        public string Posistion { get; set; }

        public static List<PlayersData> Players
        {
            get
            {
                List<PlayersData> players = new List<PlayersData>()
            {
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/01_marco_brylov.jpg", Name ="A. Bentzon", Posistion ="Innerwing", Matches = 3, Goals = 2, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/02_mikkel_andersson.jpg", Name ="Aage Albrecht", Posistion ="Angriber", Matches = 3, Goals = 1, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/03_casper_andersen.jpg", Name ="Aage Rasmussen", Posistion ="Højre back", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/04_frederik_kragh.jpg", Name ="Adda Djeziri", Posistion ="Forsvar", Matches = 2, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/05_christian_stokholm.jpg", Name ="Alexander Back", Posistion ="Forsvar", Matches = 1, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/06_kristian_geertsen.jpg", Name ="Ali Sbeihi", Posistion ="Angriber", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Name ="Allan Jensen", Posistion ="Målmand", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/08_hamid_khalidan.jpg", Name ="Anders Bøje", Posistion ="Midtbane", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/09_daniel_pedersen.jpg", Name ="Anders Sundstrup", Posistion ="Angriber", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
            };
                return players;
            }
        }

        public static int Attributes => Attributes2;


/* Unmerged change from project 'FodboldApp.iOS'
Before:
        public static int Attributes1 => attributes;
After:
        public static int Attributes1 => Attributes2;
*/
        public static int Attributes1 => Attributes2;

        public static int Attributes2 => ATTRIBUTE_COUNT;
    }
}
