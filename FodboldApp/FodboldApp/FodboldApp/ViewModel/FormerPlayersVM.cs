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

        private IQueryable<PlayerModel> _queryList { get; set; }
        public IQueryable<PlayerModel> QueryList
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

        private ObservableCollection<PlayerModel> _playersList { get; set; }
        public ObservableCollection<PlayerModel> PlayersList
        {
            get
            {
                return _playersList;
            }
            set
            {
                _playersList = value;

                if (_playersList != null)
                {
                    int i = 1;
                    foreach (PlayerModel item in PlayersList)
                    {
                        item.Index = i++;
                    }
                }

                OnPropertyChanged(nameof(PlayersList));
            }
        }

        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("formerPlayers");

            QueryList = _realm.All<PlayerModel>().OrderBy(x => x.Name);
        }

        void PlayerOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription(SelectedItem));
            ViewModelLocator.HeaderVM.UpdateContent();
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
                        PlayersList = new ObservableCollection<PlayerModel>(QueryList.ToList());
                        int i = 1 ;
                        foreach (PlayerModel item in PlayersList)
                        {
                            item.Index = i++;
                        }
                        OnPropertyChanged(nameof(PlayersList));
                    });
                }
                await Task.Delay(100);
            }
        }

        public FormerPlayersVM()
        {
            SetupRealm();
            CheckForUpdate();
            PlayerDescriptionCommand = new Command(PlayerOnTapped);
        }
    }
}
