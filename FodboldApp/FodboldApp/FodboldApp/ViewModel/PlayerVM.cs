using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class PlayerVM
    {
        Realm _realm;

        public ICommand PlayerDescriptionCommand { get; private set; }

        private IEnumerable<PlayerModel> _playerListSource { get; set; } = new ObservableCollection<PlayerModel>();

        public IEnumerable<PlayerModel> PlayerListSource
        {
            get
            {
                return _playerListSource;
            }
        }

        public void SetupPlayer()
        {
            _realm.Write(() =>
            {
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
            _playerListSource = _realm.All<PlayerModel>();
        }
        void OnTapped()
        {
            CustomStack.Instance.PlayerContent.Navigation.PushAsync(new PlayerDescription());
            HeaderVM.UpdateContent();
        }

        public PlayerVM()
        {
            _realm = Realm.GetInstance();
            SetupPlayer();
            PlayerDescriptionCommand = new Command(OnTapped);
        }
    }
}
