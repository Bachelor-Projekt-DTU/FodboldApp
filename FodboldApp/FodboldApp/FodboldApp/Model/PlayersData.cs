using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.Model
{
    class PlayersData
    {
        public string ImageURL { get; set; }
        public string Sponsor { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Birthday { get; set; }
        public int Matches { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int MVP { get; set; }
        public int Clean_Sheet { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Debut { get; set; }
        public string Former_Clubs { get; set; }
        public string Description { get; set; }
    }
}
