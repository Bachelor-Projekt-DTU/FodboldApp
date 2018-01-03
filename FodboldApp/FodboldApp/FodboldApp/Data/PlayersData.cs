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

        public static List<PlayersData> Players
        {
            get
            {
                List<PlayersData> players = new List<PlayersData>()
            {
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/01_marco_brylov.jpg", Matches = 3, Goals = 2, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/02_mikkel_andersson.jpg", Matches = 3, Goals = 1, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/03_casper_andersen.jpg", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/04_frederik_kragh.jpg", Matches = 2, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/05_christian_stokholm.jpg", Matches = 1, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/06_kristian_geertsen.jpg", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/08_hamid_khalidan.jpg", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
                new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/09_daniel_pedersen.jpg", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
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
