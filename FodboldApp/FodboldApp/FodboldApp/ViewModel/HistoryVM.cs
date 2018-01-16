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
            App.Current.MainPage.Navigation.PushAsync(new FormerPlayers());
        }
        void POTY_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new POTY());
            App.Current.MainPage.Navigation.PushAsync(new POTY());
        }
        void OverFiftyGoals_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new OverFiftyGoals());
            App.Current.MainPage.Navigation.PushAsync(new OverFiftyGoals());
        }
        void OverHundredGanes_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new OverHundredGames());
            App.Current.MainPage.Navigation.PushAsync(new OverHundredGames());
        }
        void HistoricalStandings_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new HistoricalStandings());
            App.Current.MainPage.Navigation.PushAsync(new HistoricalStandings());
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
