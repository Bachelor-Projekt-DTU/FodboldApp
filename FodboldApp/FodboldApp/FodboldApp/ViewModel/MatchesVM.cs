using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using FodboldApp.Model;
using Realms;
using Realms.Sync;

namespace FodboldApp.ViewModel
{
    class MatchesVM : INotifyPropertyChanged
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
        private IEnumerable<MatchModel> _matchList { get; set; } = new ObservableCollection<MatchModel>();
        public IEnumerable<MatchModel> MatchList
        {

            get
            {
                return _matchList;
            }
            private set
            {
                _matchList = value;
                OnPropertyChanged(nameof(MatchList));
            }
        }

        public async void SetupRealm()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/matches"));
            _realm = Realm.GetInstance(config);
            _realm.Write(() =>
            {
                _realm.RemoveAll();
                _realm.Add(new MatchModel { Teams = "BK FREM  -  Hillerød", Score = "2 - 2", ImageURL = "http://bkfrem.dk/images/hill_2.jpg" });
                _realm.Add(new MatchModel { Teams = "BK FREM  -  Hillerød", Score = "2 - 2", ImageURL = "http://bkfrem.dk/images/hill_2.jpg" });
            });
            MatchList = _realm.All<MatchModel>();
        }

        public MatchesVM()
        {
            SetupRealm();
        }
    }
}
