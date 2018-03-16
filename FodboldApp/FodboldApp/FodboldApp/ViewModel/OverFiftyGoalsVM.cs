using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class OverFiftyGoalsVM: INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public OverFiftyGoalsModel SelectedItem { get; set; }

        public ICommand PlayerDescriptionCommand { get; private set; }

        private IQueryable<OverFiftyGoalsModel> _playersList { get; set; }
        public IQueryable<OverFiftyGoalsModel> PlayersList
        {
            get
            {
                return _playersList;
            }
            set
            {
                _playersList = value;

                if (_playersList.Count() > 0)
                {
                    _realm.Write(() =>
                    {
                        int i = 0;
                        foreach (OverFiftyGoalsModel item in PlayersList)
                        {
                            item.Index = i++;
                        }
                    });
                }
                OnPropertyChanged(nameof(PlayersList));
            }
        }

        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("overfiftygoals");
            PlayersList = _realm.All<OverFiftyGoalsModel>().OrderByDescending(x => x.Goals);
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
        public OverFiftyGoalsVM()
        {
            SetupRealm();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }

    }
}
