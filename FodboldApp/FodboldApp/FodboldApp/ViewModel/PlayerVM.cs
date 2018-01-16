using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class PlayerVM: PlayersData
    {
        public ICommand PlayerDescriptionCommand { get; private set; }

        private static ObservableCollection<PlayersData> _playerListSource { get; set; } = new ObservableCollection<PlayersData>();

        public ObservableCollection<PlayersData> PlayerListSource
        {
            get
            {
                return _playerListSource;
            }
        }

        public void SetupPlayer()
        {
            _playerListSource.Add(new PlayersData {
                ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg",
                Name = "Andreas Theil Lundberg",
                Position = "Forsvar/Midtbane"});
            _playerListSource.Add(new PlayersData
            {
                ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg",
                Name = "Andreas Theil Lundberg 2",
                Position = "Forsvar/Midtbane"
            });
            _playerListSource.Add(new PlayersData
            {
                ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg",
                Name = "Andreas Theil Lundberg 3",
                Position = "Forsvar/Midtbane"
            });
        }
        void OnTapped()
        {
            CustomStack.Instance.PlayerContent.Navigation.PushAsync(new PlayerDescription());
            App.Current.MainPage.Navigation.PushAsync(new PlayerDescription());
            Console.WriteLine("Hej");
        }

        public PlayerVM()
        {
            SetupPlayer();
            PlayerDescriptionCommand = new Command(OnTapped);
        }
    }
}
