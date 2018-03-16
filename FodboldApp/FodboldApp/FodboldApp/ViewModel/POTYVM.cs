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

        public POTYModel SelectedItem { get; set; }

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

        async void Player_OnTapped()
        {
            Realm _realm = await NoInternetVM.IsConnectedOnMainPage("formerPlayers");
            PlayerModel player = _realm.Find<PlayerModel>(SelectedItem.PlayerId);
            var temp = _realm.All<PlayerModel>();
            if (player != null)
            {
                await CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription(player));
                ViewModelLocator.HeaderVM.UpdateContent();
            }
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