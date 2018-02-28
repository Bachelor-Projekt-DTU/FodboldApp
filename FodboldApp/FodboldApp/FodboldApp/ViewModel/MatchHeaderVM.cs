using FodboldApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FodboldApp.ViewModel
{
    class MatchHeaderVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
        public string DateTime { get; private set; }
        public string Location { get; private set; }
        public string Division { get; private set; }

        public bool Live
        {
            get
            {
                return Match.Status == 2;
            }
        }

        public string Scores
        {
            get
            {
                return Match.Scores;
            }
        }

        public string Teams
        {
            get
            {
                return Match.Teams;
            }
        }

        private MatchModel _match { get; set; } = new MatchModel();
        public MatchModel Match
        {
            get { return _match; }
            set
            {
                _match = value;
                OnPropertyChanged(nameof(Match));
                OnPropertyChanged(nameof(Teams));
                OnPropertyChanged(nameof(Scores));
                OnPropertyChanged(nameof(Live));
            }
        }

        public MatchHeaderVM()
        {
            DateTime = "12. august 2017 15:00";
            Location = "Skovshoved IP";
            Division = "2. Division Pulje 1";
        }
    }
}
