using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
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

        private IQueryable<POTYModel> _queryList { get; set; }
        public IQueryable<POTYModel> QueryList
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

        private ObservableCollection<POTYModel> _playersList { get; set; }
        public ObservableCollection<POTYModel> PlayersList
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
            QueryList = _realm.All<POTYModel>().OrderByDescending(x => x.Year);
        }

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
                        PlayersList = new ObservableCollection<POTYModel>(QueryList.ToList());
                        int i = 0;
                        foreach (POTYModel item in PlayersList)
                        {
                            item.Index = i++;
                        }
                        OnPropertyChanged(nameof(PlayersList));
                    });
                }
                await Task.Delay(100);
            }
        }

        public POTYVM()
        {
            SetupRealm();
            CheckForUpdate();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }
    }
}