using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FodboldApp.ViewModel
{
    class ClubVM : ClubsData, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ClubVM ()
        {
        ClubList.Add(new ClubsData { ClubName = "BK Frem" });
        ClubList.Add(new ClubsData { ClubName = "Klub 2" });
        ClubList.Add(new ClubsData { ClubName = "Klub 3" });
        ClubList.Add(new ClubsData { ClubName = "Klub 4" });
        ClubList.Add(new ClubsData { ClubName = "Klub 5" });

     }

        public List<ClubsData> clubListSource
        {
            get
            {
                return ClubList;
            }
        }
    }
}
