using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using FodboldApp.View.UserControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class PlayerVM: PlayersData
    {
        private static List<PlayersData> Players = new List<PlayersData>();
        public ICommand ShowPlayerDescriptionCommand { get; private set; }

        public List<PlayersData> PlayerListSource
        {
            get
            {
                return Players;
            }
        }

        public void SetupPlayer()
        {
            Players.Clear();
            Players.Add(new PlayersData {
                ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg",
                Name = "Andreas Theil Lundberg",
                Position = "Forsvar/Midtbane"});
            Players.Add(new PlayersData
            {
                ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg",
                Name = "Andreas Theil Lundberg 2",
                Position = "Forsvar/Midtbane"
            });
            Players.Add(new PlayersData
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
            ShowPlayerDescriptionCommand = new Command(OnTapped);
        }
    }
}
