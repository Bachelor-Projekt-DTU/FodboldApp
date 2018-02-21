using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class OverFiftyGoalsVM: INotifyPropertyChanged
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
        public ICommand PlayerDescriptionCommand { get; private set; }

        private IEnumerable<OverFiftyGoalsModel> _playersList { get; set; } = new ObservableCollection<OverFiftyGoalsModel>();
        public IEnumerable<OverFiftyGoalsModel> PlayersList
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
            _realm = await NoInternetVM.IsConnectedOnMainPage("over50goals");

            //int index = 0;
            //var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            //SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/over50goals"));
            //_realm = Realm.GetInstance(config);
            //_realm.Write(() =>
            //{
            //    _realm.RemoveAll();
            //    _realm.Add(new OverFiftyGoalsModel { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297", Index = index++ });
            //    _realm.Add(new OverFiftyGoalsModel { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297", Index = index++ });
            //    _realm.Add(new OverFiftyGoalsModel { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297", Index = index++ });
            //    _realm.Add(new OverFiftyGoalsModel { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297", Index = index++ });
            //    _realm.Add(new OverFiftyGoalsModel { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297", Index = index++ });
            //});
            PlayersList = _realm.All<OverFiftyGoalsModel>();
            //_realm.Dispose();
        }

            void Player_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription());
            HeaderVM.UpdateContent();
        }
        public OverFiftyGoalsVM()
        {
            SetupRealm();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }

    }
}
