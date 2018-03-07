using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class POTYVM : INotifyPropertyChanged
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
        private IEnumerable<POTYModel> _playersList { get; set; } = new ObservableCollection<POTYModel>();
        public IEnumerable<POTYModel> PlayersList
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
        private void SetupPlayerList()
        {
        }
        void Player_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription(new PlayerModel()));
            ViewModelLocator.HeaderVM.UpdateContent();
        }

        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("POTY");

            //var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            //SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/chat"));
            //_realm = Realm.GetInstance(config);
            //int index = 0;
            //_realm.Write(() =>
            //{
            //    _realm.RemoveAll();
            //    _realm.Add(new POTYModel { Year = "1958", Name = "George Lees", Index = index++ });
            //    _realm.Add(new POTYModel { Year = "1958", Name = "George Lees", Index = index++ });
            //    _realm.Add(new POTYModel { Year = "1958", Name = "George Lees", Index = index++ });
            //    _realm.Add(new POTYModel { Year = "1958", Name = "George Lees", Index = index++ });
            //    _realm.Add(new POTYModel { Year = "1958", Name = "George Lees", Index = index++ });
            //});
            PlayersList = _realm.All<POTYModel>();
        }
        public POTYVM()
        {
            SetupRealm();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }
    }
}