using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FodboldApp
{
    class ClubsData
    {
        public string ClubName { get; set; }

        public static List<ClubsData> ClubList { get; set; } = new List<ClubsData>();
    }
}
