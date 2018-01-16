using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class OverHundredGamesVM: INotifyPropertyChanged
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
        private ObservableCollection<OverHundredGamesData> _playersList { get; set; } = new ObservableCollection<OverHundredGamesData>();
        public ObservableCollection<OverHundredGamesData> PlayerList
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
            _playersList.Add(new OverHundredGamesData { Name = "Per Wind", Period = "1973 - 1998", Games = "590" });
            _playersList.Add(new OverHundredGamesData { Name = "Per Wind", Period = "1973 - 1998", Games = "590" });
            _playersList.Add(new OverHundredGamesData { Name = "Per Wind", Period = "1973 - 1998", Games = "590" });
            _playersList.Add(new OverHundredGamesData { Name = "Per Wind", Period = "1973 - 1998", Games = "590" });
            _playersList.Add(new OverHundredGamesData { Name = "Per Wind", Period = "1973 - 1998", Games = "590" });
        }
        void Player_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription());
            App.Current.MainPage.Navigation.PushAsync(new PlayerDescription());
        }
        public OverHundredGamesVM()
        {
            SetupPlayerList();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }

    }
}
