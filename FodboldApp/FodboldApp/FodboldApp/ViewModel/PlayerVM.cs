using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class PlayerVM : INotifyPropertyChanged
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

        private IEnumerable<PlayerModel> _playerListSource { get; set; } = new ObservableCollection<PlayerModel>();

        public IEnumerable<PlayerModel> PlayerListSource
        {
            get
            {
                return _playerListSource;
            }
            set
            {
                _playerListSource = value;
                OnPropertyChanged(nameof(PlayerListSource));
            }
        }

        public async void SetupRealm()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/players"));
            _realm = Realm.GetInstance(config);

            _realm.Write(() =>
                {
                    _realm.RemoveAll();
                    _realm.Add(new PlayerModel
                    {
                        ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg",
                        Name = "Andreas Theil Lundberg",
                        Position = "Forsvar/Midtbane"
                    });
                    _realm.Add(new PlayerModel
                    {
                        ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg",
                        Name = "Andreas Theil Lundberg 2",
                        Position = "Forsvar/Midtbane"
                    });
                    _realm.Add(new PlayerModel
                    {
                        ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg",
                        Name = "Andreas Theil Lundberg 3",
                        Position = "Forsvar/Midtbane"
                    });
                });
            PlayerListSource = _realm.All<PlayerModel>();
        }

        void OnTapped()
        {
            CustomStack.Instance.PlayerContent.Navigation.PushAsync(new PlayerDescription());
            HeaderVM.UpdateContent();
        }

        public PlayerVM()
        {
            _realm = Realm.GetInstance();
            SetupRealm();
            PlayerDescriptionCommand = new Command(OnTapped);
        }
    }
}
