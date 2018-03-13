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
    class OverHundredGamesVM : INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ICommand PlayerDescriptionCommand { get; private set; }
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
        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("overhundredgames");
            var temp = _realm.All<OverHundredGamesModel>().ToList().OrderByDescending(x => Int32.Parse(x.Games));
            PlayersList = new ObservableCollection<OverHundredGamesModel>(temp);

            _realm.Write(() =>
            {
                int i = 0;
                foreach (OverHundredGamesModel item in PlayersList)
                {
                    item.Index = i++;
                }
            });
        }
        void Player_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription(new PlayerModel()));
            ViewModelLocator.HeaderVM.UpdateContent();
        }
        public OverHundredGamesVM()
        {
            SetupRealm();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }

    }
}
