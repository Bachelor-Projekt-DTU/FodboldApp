using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class POTYVM : INotifyPropertyChanged
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
        private ObservableCollection<POTYsData> _playersList { get; set; } = new ObservableCollection<POTYsData>();
        public ObservableCollection<POTYsData> PlayersList
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
            _playersList.Add(new POTYsData { Year = "1958", Name = "George Lees" });
            _playersList.Add(new POTYsData { Year = "1958", Name = "George Lees" });
            _playersList.Add(new POTYsData { Year = "1958", Name = "George Lees" });
            _playersList.Add(new POTYsData { Year = "1958", Name = "George Lees" });
            _playersList.Add(new POTYsData { Year = "1958", Name = "George Lees" });
        }
        void Player_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription());
            App.Current.MainPage.Navigation.PushAsync(new PlayerDescription());
        }
        public POTYVM()
        {
            SetupPlayerList();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }
    }
}