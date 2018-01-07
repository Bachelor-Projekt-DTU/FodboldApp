using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Data
{
    class OverFiftyGoalsData
    {    
        public string Name { get; set; }
        public string Period { get; set; }
        public string Goals_Games { get; set; }


        public static List<OverFiftyGoalsData> Players
        {
            get
            {
                List<OverFiftyGoalsData> players = new List<OverFiftyGoalsData>()
            {
                new OverFiftyGoalsData() {Name = "Pauli Jørgensen", Period = "1925 - 1942", Goals_Games = "288*/297"},
                new OverFiftyGoalsData() {Name = "John Hansen", Period = "1943 - 1960", Goals_Games = "113/115"},
                new OverFiftyGoalsData() {Name = "Sophus \"Krølben\" Nielsen", Period = "1904 - 1921", Goals_Games = "111**/137"},
                new OverFiftyGoalsData() {Name = "Ole Mørch", Period = "1967 - 1980", Goals_Games = "109/344"},
                new OverFiftyGoalsData() {Name = "Martin Jeppesen", Period = "1992 - 2012", Goals_Games = "104/318"},
                };
                return players;
            }
        }
    }
}
