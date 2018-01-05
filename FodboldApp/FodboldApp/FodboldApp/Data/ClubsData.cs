using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FodboldApp
{
    class ClubsData
    {
        public string ClubName { get; set; }

        public static List<ClubsData> ClubList
        {
            get
            {
                List<ClubsData> clubs = new List<ClubsData>()
            {
                new ClubsData { ClubName = "BK Frem" },
                new ClubsData { ClubName = "Klub 2" },
                new ClubsData { ClubName = "Klub 3" },
                new ClubsData { ClubName = "Klub 4" },
                new ClubsData { ClubName = "Klub 5" }
            };
                return clubs;
            }
        }
    }
}
