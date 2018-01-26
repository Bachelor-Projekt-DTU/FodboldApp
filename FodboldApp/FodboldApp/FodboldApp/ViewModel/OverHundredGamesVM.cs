using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class OverHundredGamesVM: INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public ICommand PlayerDescriptionCommand { get; private set; }
        private IEnumerable<OverHundredGamesModel> _playersList { get; set; } = new ObservableCollection<OverHundredGamesModel>();
        public IEnumerable<OverHundredGamesModel> PlayersList
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
        private void SetupPlayerList()
        {
            int index = 0;
            _realm.Write(() =>
            {
                _realm.Add(new OverHundredGamesModel { Name = "Per Wind", Period = "1973 - 1998", Games = "590", Index = index++ });
                _realm.Add(new OverHundredGamesModel { Name = "Per Wind", Period = "1973 - 1998", Games = "590", Index = index++ });
                _realm.Add(new OverHundredGamesModel { Name = "Per Wind", Period = "1973 - 1998", Games = "590", Index = index++ });
                _realm.Add(new OverHundredGamesModel { Name = "Per Wind", Period = "1973 - 1998", Games = "590", Index = index++ });
                _realm.Add(new OverHundredGamesModel { Name = "Per Wind", Period = "1973 - 1998", Games = "590", Index = index++ });
            });
            _playersList = _realm.All<OverHundredGamesModel>();
        }
        void Player_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new PlayerDescription());
            HeaderVM.UpdateContent();
        }
        public OverHundredGamesVM()
        {
            _realm = Realm.GetInstance();
            SetupPlayerList();
            PlayerDescriptionCommand = new Command(Player_OnTapped);
        }

    }
}
