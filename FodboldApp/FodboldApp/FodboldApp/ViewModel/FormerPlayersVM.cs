using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class FormerPlayersVM: INotifyPropertyChanged
    {
        Realm _realm;

        private PlayerModel _selectedItem { get; set; }
        public PlayerModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ICommand PlayerDescriptionCommand { get; private set; }
        private IQueryable<PlayerModel> _playersList { get; set; }
        public IQueryable<PlayerModel> PlayersList
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

            PlayersList = _realm.All<PlayerModel>().OrderBy(x => x.Name);

            _realm.Write(() =>
            {
                int i = 1;
                foreach (PlayerModel item in PlayersList)
                {
                    item.Index = i++;
                }
            });
        }

        void PlayerOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription(SelectedItem));
            ViewModelLocator.HeaderVM.UpdateContent();
        }
        public FormerPlayersVM()
        {
            SetupRealm();
            PlayerDescriptionCommand = new Command(PlayerOnTapped);
        }
    }
}
