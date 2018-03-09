using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

            PlayersList = _realm.All<POTYModel>();
        }
        public POTYVM()
        {
            SetupRealm();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }
    }
}