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
        public ICommand TempCommand { get; private set; }

        void FormerPlayersOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new FormerPlayers());
            HeaderVM.UpdateContent();
        }
        void POTYOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new POTY());
            HeaderVM.UpdateContent();
        }
        void OverFiftyGoalsOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new OverFiftyGoals());
            HeaderVM.UpdateContent();
        }
        void OverHundredGanesOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new OverHundredGames());
            HeaderVM.UpdateContent();
        }
        void HistoricalStandingsOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new HistoricalStandings());
            HeaderVM.UpdateContent();
        }

        void Temp_OnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new Chat());
            HeaderVM.UpdateContent();
        }

        public HistoryVM()
        {
            FormerPlayersCommand = new Command(FormerPlayersOnTapped);
            POTYCommand = new Command(POTYOnTapped);
            OverFiftyGoalsCommand = new Command(OverFiftyGoalsOnTapped);
            OverHundredGamesCommand = new Command(OverHundredGanesOnTapped);
            HistoricalStandingsCommand = new Command(HistoricalStandingsOnTapped);
            TempCommand = new Command(Temp_OnTapped);
        }
    }
}
