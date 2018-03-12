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
    class FormerPlayersVM: INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

            PlayersList = _realm.All<FormerPlayerModel>();
        }

        void PlayerOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription(new PlayerModel()));
            ViewModelLocator.HeaderVM.UpdateContent();
        }
        public FormerPlayersVM()
        {
            SetupRealm();
            PlayerDescriptionCommand = new Command(PlayerOnTapped);
        }
    }
}
