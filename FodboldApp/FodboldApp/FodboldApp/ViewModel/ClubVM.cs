using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace FodboldApp.ViewModel
{
    class ClubVM : ClubsData
    {
        public static ObservableCollection<ClubsData> _clubListSource = new ObservableCollection<ClubsData>();
        public ObservableCollection<ClubsData> ClubListSource
        {
            get
            {
                return _clubListSource;
            }
        }

        public ClubVM ()
        {
        _clubListSource.Add(new ClubsData { ClubName = "BK Frem" });
        _clubListSource.Add(new ClubsData { ClubName = "Klub 2" });
        _clubListSource.Add(new ClubsData { ClubName = "Klub 3" });
        _clubListSource.Add(new ClubsData { ClubName = "Klub 4" });
        _clubListSource.Add(new ClubsData { ClubName = "Klub 5" });
        }  
    }
}
