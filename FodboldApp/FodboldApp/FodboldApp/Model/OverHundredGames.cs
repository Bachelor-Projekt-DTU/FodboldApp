using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Data
{
    class OverHundredGamesData
    {
        public string Name { get; set; }
        public string Period { get; set; }
        public string Games { get; set; }

        public static List<OverHundredGamesData> Players { get; set; } = new List<OverHundredGamesData>();
     
                //List<OverHundredGamesData> players = new List<OverHundredGamesData>()
            //{
            //    new OverHundredGamesData() {Name = "Per Wind", Period = "1973 - 1998", Games = "590"},
            //    new OverHundredGamesData() {Name = "Lars Larsen", Period = "1970 - 1988", Games = "514"},
            //    new OverHundredGamesData() {Name = "Tim Ilsø", Period = "1996 - 2012", Games = "372"},
            //    new OverHundredGamesData() {Name = "Ole Mørch", Period = "1967 - 1980", Games = "344"},
            //    new OverHundredGamesData() {Name = "Flemming Ahlberg", Period = "1967 - 1979", Games = "331"},
            //    };            
    }
}
