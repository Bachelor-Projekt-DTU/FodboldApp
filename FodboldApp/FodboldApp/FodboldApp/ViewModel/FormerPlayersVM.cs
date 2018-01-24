using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
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
        private void SetupPlayerList()
        {
            int index = 0;
            _realm.Write(() =>
            {
                _realm.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
                _realm.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
                _realm.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
                _realm.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
                _realm.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
            });
            _playersList = _realm.All<FormerPlayerModel>();
        }
        void Player_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription());
            App.Current.MainPage.Navigation.PushAsync(new PlayerDescription());
        }
        public FormerPlayersVM()
        {
            _realm = Realm.GetInstance();
            SetupPlayerList();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }
    }
}
