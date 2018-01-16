using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.Model
{
    class HistoricalStandingsData: INotifyPropertyChanged
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
        public string TournamentName { get; set; }
        public string Year { get; set; }
        public string Standing { get; set; }
        public string Games { get; set; }
        public string Record { get; set; }
        public string Points { get; set; }
        public string TournamentLabelName { get; set; }
        public bool _selected { get; set; } = false;
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }
    }
}
