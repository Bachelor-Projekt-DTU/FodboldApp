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
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        
        public string Teams { get; private set; }
        public string DateTime { get; private set; }
        public string Location { get; private set; }
        public string Division { get; private set; }

        private bool _live { get; set; } = false;
        public bool Live
        {
            get
            {
                return _live;
            }
            set
            {
                _live = value;
                OnPropertyChanged(nameof(Live));
            }
        }

        private string _score { get; set; }
        public string Score
        {
            get
            {
                return _score;
            }
            private set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public MatchHeaderVM()
        {
            Live = false;
            Teams = "Skovshoved - Boldklubben Frem";
            DateTime = "12. august 2017 15:00";
            Location = "Skovshoved IP";
            Division = "2. Division Pulje 1";
            Score = "2 - 2";
        }
    }
}
