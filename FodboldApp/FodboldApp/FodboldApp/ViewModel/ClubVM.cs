using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FodboldApp.ViewModel
{
    class ClubVM : ClubsData
    {
        public static List<ClubsData> ClubList = new List<ClubsData>();

        public ClubVM ()
        {
        ClubList.Add(new ClubsData { ClubName = "BK Frem" });
        ClubList.Add(new ClubsData { ClubName = "Klub 2" });
        ClubList.Add(new ClubsData { ClubName = "Klub 3" });
        ClubList.Add(new ClubsData { ClubName = "Klub 4" });
        ClubList.Add(new ClubsData { ClubName = "Klub 5" });

     }

        public List<ClubsData> ClubListSource
        {
            get
            {
                return ClubList;
            }
        }
    }
}
