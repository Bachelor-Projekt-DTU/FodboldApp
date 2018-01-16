using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
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
        private ObservableCollection<OverFiftyGoalsData> _playersList { get; set; } = new ObservableCollection<OverFiftyGoalsData>();
        public ObservableCollection<OverFiftyGoalsData> PlayerList
        {
            get
            {
                return _playersList;
            }
            set
            {
                _playersList = value;
                OnPropertyChanged(nameof(PlayerList));
            }
        }
        private void SetupPlayerList()
        {
            _playersList.Add(new OverFiftyGoalsData { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297" });
            _playersList.Add(new OverFiftyGoalsData { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297" });
            _playersList.Add(new OverFiftyGoalsData { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297" });
            _playersList.Add(new OverFiftyGoalsData { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297" });
            _playersList.Add(new OverFiftyGoalsData { Name = "Pauli Jørgensen", Period = "1973 - 1998", Goals_Games = "288*/297" });
        }
        void Player_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription());
            App.Current.MainPage.Navigation.PushAsync(new PlayerDescription());
        }
        public OverFiftyGoalsVM()
        {
            SetupPlayerList();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }

    }
}
