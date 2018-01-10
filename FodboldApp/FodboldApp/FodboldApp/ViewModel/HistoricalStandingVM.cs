using FodboldApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FodboldApp.ViewModel
{
    class HistoricalStandingVM: HistoricalStandingsData, INotifyPropertyChanged
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

        public HistoricalStandingVM()
        {
            HistoricalStandingsDataList.Add(new HistoricalStandingsData { TournamentName = "LANDSFODBOLDTURNERINGEN" });
            HistoricalStandingsDataList.Add(new HistoricalStandingsData { TournamentName = "MESTERSKABSSERIEN" });
            HistoricalStandingsDataList.Add(new HistoricalStandingsData { TournamentName = "Kriseturneringen – kreds 3" });
            HistoricalStandingsDataList.Add(new HistoricalStandingsData { TournamentName = "DANMARKSTURNERINGEN – 1. Division" });
            HistoricalStandingsDataList.Add(new HistoricalStandingsData { TournamentName = "DANMARKSTURNERINGEN – 2. Division" });
        }
        public List<HistoricalStandingsData> standingsListSource
        {
            get
            {
                return HistoricalStandingsDataList;
            }
        }
        
    }
}
