using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FodboldApp.ViewModel
{
    class TournamentVM : INotifyPropertyChanged
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
        private ObservableCollection<TournamentsData> _playersList { get; set; } = new ObservableCollection<TournamentsData>();
        public ObservableCollection<TournamentsData> PlayersList
        {
            get
            {
                return _playersList;
            }
        }
        private void SetupPlayerList()
        {
            int index = 0;
            _playersList.Add(new TournamentsData { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
            _playersList.Add(new TournamentsData { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
            _playersList.Add(new TournamentsData { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
            _playersList.Add(new TournamentsData { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
            _playersList.Add(new TournamentsData { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
        }
        
        public TournamentVM()
        {
            SetupPlayerList();
        }
    }
}
