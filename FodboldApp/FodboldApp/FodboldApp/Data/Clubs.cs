using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FodboldApp
{
    class Clubs
    {
        public string ClubName { get; set; }

        public static List<Clubs> ClubList
        {
            get
            {
                List<Clubs> clubs = new List<Clubs>()
            {
                new Clubs { ClubName = "BK Frem" },
                new Clubs { ClubName = "Klub 2" },
                new Clubs { ClubName = "Klub 3" },
                new Clubs { ClubName = "Klub 4" },
                new Clubs { ClubName = "Klub 5" }
            };
                return clubs;
            }
        }
    }
}
