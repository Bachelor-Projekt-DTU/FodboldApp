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
        private ObservableCollection<POTYModel> _playersList { get; set; } = new ObservableCollection<POTYModel>();
        public ObservableCollection<POTYModel> PlayersList
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
            _playersList.Add(new POTYModel { Year = "1958", Name = "George Lees", Index = index++ });
            _playersList.Add(new POTYModel { Year = "1958", Name = "George Lees", Index = index++ });
            _playersList.Add(new POTYModel { Year = "1958", Name = "George Lees", Index = index++ });
            _playersList.Add(new POTYModel { Year = "1958", Name = "George Lees", Index = index++ });
            _playersList.Add(new POTYModel { Year = "1958", Name = "George Lees", Index = index++ });
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