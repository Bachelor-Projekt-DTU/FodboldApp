using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FodboldApp.ViewModel
{
    class TournamentVM : INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private IEnumerable<TournamentModel> _playersList { get; set; } = new ObservableCollection<TournamentModel>();
        public IEnumerable<TournamentModel> PlayersList
        {
            get
            {
                return _playersList;
            }
        }
        private void SetupPlayerList()
        {
            int index = 0;
            _realm.Write(() =>
            {
                _realm.Add(new TournamentModel { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
                _realm.Add(new TournamentModel { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
                _realm.Add(new TournamentModel { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
                _realm.Add(new TournamentModel { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
                _realm.Add(new TournamentModel { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
            });
            _playersList = _realm.All<TournamentModel>();
        }
        
        public TournamentVM()
        {
            _realm = Realm.GetInstance();
            SetupPlayerList();
        }
    }
}
