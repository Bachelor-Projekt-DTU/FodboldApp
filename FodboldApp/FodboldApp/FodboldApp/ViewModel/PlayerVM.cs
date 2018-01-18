using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class PlayerVM: PlayerModel
    {
        public ICommand PlayerDescriptionCommand { get; private set; }

        private static ObservableCollection<PlayerModel> _playerListSource { get; set; } = new ObservableCollection<PlayerModel>();

        public ObservableCollection<PlayerModel> PlayerListSource
        {
            get
            {
                return _playerListSource;
            }
        }

        public void SetupPlayer()
        {
            _playerListSource.Add(new PlayerModel {
                ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg",
                Name = "Andreas Theil Lundberg",
                Position = "Forsvar/Midtbane"});
            _playerListSource.Add(new PlayerModel
            {
                ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg",
                Name = "Andreas Theil Lundberg 2",
                Position = "Forsvar/Midtbane"
            });
            _playerListSource.Add(new PlayerModel
            {
                ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg",
                Name = "Andreas Theil Lundberg 3",
                Position = "Forsvar/Midtbane"
            });
        }
        void OnTapped()
        {
            CustomStack.Instance.PlayerContent.Navigation.PushAsync(new PlayerDescription());
            HeaderVM.UpdateContent();
        }

        public PlayerVM()
        {
            SetupPlayer();
            PlayerDescriptionCommand = new Command(OnTapped);
        }
    }
}
