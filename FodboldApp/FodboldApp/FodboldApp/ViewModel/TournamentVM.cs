using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using Realms.Sync;
using System;
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
            set
            {
                _playersList = value;
                OnPropertyChanged(nameof(PlayersList));
            }
        }
        public async void SetupRealm()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/tournament"));
            _realm = Realm.GetInstance(config);

            int index = 0;
            //_realm.Write(() =>
            //{
            //    _realm.RemoveAll();
            //    _realm.Add(new TournamentModel { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
            //    _realm.Add(new TournamentModel { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
            //    _realm.Add(new TournamentModel { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
            //    _realm.Add(new TournamentModel { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
            //    _realm.Add(new TournamentModel { ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Goals = "55", Games = "100", Assist = "50", MVP = "3", Clean_Sheet = "0", Index = index++ });
            //});
            PlayersList = _realm.All<TournamentModel>();
            //_realm.Dispose();
        }
        
        public TournamentVM()
        {
            SetupRealm();
        }
    }
}
