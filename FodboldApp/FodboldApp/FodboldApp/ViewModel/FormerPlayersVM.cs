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
    class FormerPlayersVM: INotifyPropertyChanged
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
        private IEnumerable<FormerPlayerModel> _playersList { get; set; } = new ObservableCollection<FormerPlayerModel>();
        public IEnumerable<FormerPlayerModel> PlayersList
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
            _realm = await NoInternetVM.IsConnectedOnMainPage("formerPlayers");

            var index = 0;
            //var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            //SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/formerPlayers"));
            //_realm = Realm.GetInstance(config);
            //_realm.Write(() =>
            //{
            //    _realm.RemoveAll();
            //    _realm.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
            //    _realm.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
            //    _realm.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
            //    _realm.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
            //    _realm.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
            //});
            PlayersList = _realm.All<FormerPlayerModel>();
        }

        void PlayerOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription());
            HeaderVM.UpdateContent();
        }
        public FormerPlayersVM()
        {
            SetupRealm();
            PlayerDescriptionCommand = new Command(PlayerOnTapped);
        }
    }
}
