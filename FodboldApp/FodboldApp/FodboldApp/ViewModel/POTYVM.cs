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
    class POTYVM : INotifyPropertyChanged
    {
        Realm _realm;

        private POTYModel _selectedItem { get; set; }
        public POTYModel SelectedItem
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
        private IQueryable<POTYModel> _playersList { get; set; }
        public IQueryable<POTYModel> PlayersList
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
        
        void Player_OnTapped()
        {
            _realm = NoInternetVM.IsConnectedOnMainPage("formerPlayers").GetAwaiter().GetResult();
            PlayerModel temp = _realm.All<PlayerModel>().Where(x => x.Name.Trim() == SelectedItem.Name.Trim()).First();
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription(new PlayerModel()));
            ViewModelLocator.HeaderVM.UpdateContent();
        }

        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("POTY");

            PlayersList = _realm.All<POTYModel>().OrderByDescending(x => x.Year);

            _realm.Write(() =>
            {
                int i = 0;
                foreach (POTYModel item in PlayersList)
                {
                    item.Index = i++;
                }
            });
        }

        public POTYVM()
        {
            SetupRealm();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }
    }
}