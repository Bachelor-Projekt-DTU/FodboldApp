using FodboldApp.Model;
using FodboldApp.View.UserControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class PlayerVM: PlayersData
    {
        private static List<PlayersData> Players = new List<PlayersData>();

        private int StatsRows = 10;
        private int DescriptionRows = 2;

        public PlayerVM()
        {
          SetupPlayer();  
        }

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
    }
}
