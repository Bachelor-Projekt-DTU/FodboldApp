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
        public ICommand PlayerDescriptionCommand { get; private set; }

        private ObservableCollection<OverFiftyGoalsModel> _playersList { get; set; }
        public ObservableCollection<OverFiftyGoalsModel> PlayersList
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
            _realm = await NoInternetVM.IsConnectedOnMainPage("overfiftygoals");
            var temp = _realm.All<OverFiftyGoalsModel>().ToList().OrderByDescending(x => Int32.Parse(x.Goals_Games.Split('/')[0]. Trim('*')));

            PlayersList = new ObservableCollection<OverFiftyGoalsModel>(temp);

            _realm.Write(() =>
            {
                int i = 0;
                foreach (OverFiftyGoalsModel item in PlayersList)
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
        public OverFiftyGoalsVM()
        {
            SetupRealm();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }

    }
}
