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
        private IQueryable<OverHundredGamesModel> _playersList { get; set; }
        public IQueryable<OverHundredGamesModel> PlayersList
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
                    Console.WriteLine("STAPLE GUN:" + _playersList.Count());
                    int i = 0;
                    foreach (OverHundredGamesModel item in PlayersList)
                    {
                        item.Index = i++;
                    }
                }

                OnPropertyChanged(nameof(PlayersList));
            }
        }
        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPageGuaranteeData("overhundredgames");
            PlayersList = _realm.All<OverHundredGamesModel>().OrderByDescending(x => x.Games);
            
                
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
