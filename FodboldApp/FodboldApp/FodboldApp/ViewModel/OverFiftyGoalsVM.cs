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
        private void SetupPlayerList()
        {
            int index = 0;
            _realm.Write(() =>
            {
                _realm.Add(new OverFiftyGoalsModel { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297", Index = index++ });
                _realm.Add(new OverFiftyGoalsModel { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297", Index = index++ });
                _realm.Add(new OverFiftyGoalsModel { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297", Index = index++ });
                _realm.Add(new OverFiftyGoalsModel { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297", Index = index++ });
                _realm.Add(new OverFiftyGoalsModel { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297", Index = index++ });
            });
            _playersList = _realm.All<OverFiftyGoalsModel>();
        }
        void Player_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription());
            App.Current.MainPage.Navigation.PushAsync(new PlayerDescription());
        }
        public OverFiftyGoalsVM()
        {
            _realm = Realm.GetInstance();
            SetupPlayerList();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }

    }
}
