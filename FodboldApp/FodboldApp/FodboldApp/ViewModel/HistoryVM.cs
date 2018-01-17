using FodboldApp.Stack;
using FodboldApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class HistoryVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ICommand FormerPlayersCommand { get; private set; }
        public ICommand POTYCommand { get; private set; }
        public ICommand OverFiftyGoalsCommand { get; private set; }
        public ICommand OverHundredGamesCommand { get; private set; }
        public ICommand HistoricalStandingsCommand { get; private set; }

        void FormerPlayers_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new FormerPlayers());
            HeaderVM.UpdateContent();
        }
        void POTY_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new POTY());
            HeaderVM.UpdateContent();
        }
        void OverFiftyGoals_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new OverFiftyGoals());
            HeaderVM.UpdateContent();
        }
        void OverHundredGanes_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new OverHundredGames());
            HeaderVM.UpdateContent();
        }
        void HistoricalStandings_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new HistoricalStandings());
            HeaderVM.UpdateContent();
        }

        public HistoryVM()
        {
            FormerPlayersCommand = new Command(FormerPlayers_OnTapped);
            POTYCommand = new Command(POTY_OnTapped);
            OverFiftyGoalsCommand = new Command(OverFiftyGoals_OnTapped);
            OverHundredGamesCommand = new Command(OverHundredGanes_OnTapped);
            HistoricalStandingsCommand = new Command(HistoricalStandings_OnTapped);
        }
    }
}
