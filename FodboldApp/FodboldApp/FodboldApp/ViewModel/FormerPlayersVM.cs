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
    class FormerPlayersVM: INotifyPropertyChanged
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
        private ObservableCollection<FormerPlayerModel> _playersList { get; set; } = new ObservableCollection<FormerPlayerModel>();
        public ObservableCollection<FormerPlayerModel> PlayersList
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
            _playersList.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
            _playersList.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
            _playersList.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
            _playersList.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
            _playersList.Add(new FormerPlayerModel { Player = "A. Bentzon - Højre Innerwing", Index = index++ });
        }
        void PlayerOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription());
            App.Current.MainPage.Navigation.PushAsync(new PlayerDescription());
        }
        public FormerPlayersVM()
        {
            SetupPlayerList();
            PlayerDescriptionCommand = new Command(PlayerOnTapped);
        }
    }
}
