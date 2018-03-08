using FodboldApp.Stack;
using FodboldApp.View;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class HistoryVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand FormerPlayersCommand { get; private set; }
        public ICommand POTYCommand { get; private set; }
        public ICommand OverFiftyGoalsCommand { get; private set; }
        public ICommand OverHundredGamesCommand { get; private set; }
        public ICommand HistoricalStandingsCommand { get; private set; }
        public ICommand ChangeClubCommand { get; private set; }

        void FormerPlayersOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new FormerPlayers());
            ViewModelLocator.HeaderVM.UpdateContent();
        }
        void POTYOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new POTY());
            ViewModelLocator.HeaderVM.UpdateContent();
        }
        void OverFiftyGoalsOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new OverFiftyGoals());
            ViewModelLocator.HeaderVM.UpdateContent();
        }
        void OverHundredGanesOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new OverHundredGames());
            ViewModelLocator.HeaderVM.UpdateContent();
        }
        void HistoricalStandingsOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new HistoricalStandings());
            ViewModelLocator.HeaderVM.UpdateContent();
        }
        void ChangeClubOnTapped()
        {
            CustomStack.Instance.HistoryContent.Navigation.PushAsync(new Settings());
            ViewModelLocator.HeaderVM.UpdateContent();
        }

        public HistoryVM()
        {
            FormerPlayersCommand = new Command(FormerPlayersOnTapped);
            POTYCommand = new Command(POTYOnTapped);
            OverFiftyGoalsCommand = new Command(OverFiftyGoalsOnTapped);
            OverHundredGamesCommand = new Command(OverHundredGanesOnTapped);
            HistoricalStandingsCommand = new Command(HistoricalStandingsOnTapped);
            ChangeClubCommand = new Command(ChangeClubOnTapped);
        }
    }
}
