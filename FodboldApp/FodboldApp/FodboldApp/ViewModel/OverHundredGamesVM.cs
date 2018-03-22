using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class OverHundredGamesVM : INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public OverHundredGamesModel SelectedItem { get; set; }

        public ICommand PlayerDescriptionCommand { get; private set; }

        private IQueryable<OverHundredGamesModel> _queryList { get; set; }
        public IQueryable<OverHundredGamesModel> QueryList
        {
            get
            {
                return _queryList;
            }
            set
            {
                _queryList = value;
                OnPropertyChanged(nameof(QueryList));
            }
        }

        private ObservableCollection<OverHundredGamesModel> _playersList { get; set; }
        public ObservableCollection<OverHundredGamesModel> PlayersList
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

        //used to avoid bug on initial realm setup
        private async void CheckForUpdate()
        {
            int oldCount = 0;
            while (true)
            {
                if (QueryList != null && QueryList.Count() != oldCount)
                {
                    oldCount = QueryList.Count();
                    _realm.Write(() =>
                    {
                        PlayersList = new ObservableCollection<OverHundredGamesModel>(QueryList.ToList());
                        int i = 0;
                        foreach (OverHundredGamesModel item in PlayersList)
                        {
                            item.Index = i++;
                        }
                    OnPropertyChanged(nameof(PlayersList));
                    });
                }
                await Task.Delay(500);
            }
        }

        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("overhundredgames");
            QueryList = _realm.All<OverHundredGamesModel>().OrderByDescending(x => x.Games);
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

        public OverHundredGamesVM()
        {
            SetupRealm();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
            CheckForUpdate();
        }

    }
}
