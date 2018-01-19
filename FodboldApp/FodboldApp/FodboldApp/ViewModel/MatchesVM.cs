using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using FodboldApp.Model;

namespace FodboldApp.ViewModel
{
    class MatchesVM : INotifyPropertyChanged
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
        private ObservableCollection<MatchModel> _matchList { get; set; } = new ObservableCollection<MatchModel>();
        public ObservableCollection<MatchModel> MatchList
        {

            get
            {
                return _matchList;
            }
            private set
            {
                _matchList = value;
                OnPropertyChanged(nameof(MatchList));
            }
        }
        

        public MatchesVM()
        {
            _matchList.Add(new MatchModel { Teams = "BK FREM  -  Hillerød", Score = "2 - 2", ImageURL = "http://bkfrem.dk/images/hill_2.jpg" });
            _matchList.Add(new MatchModel { Teams = "BK FREM  -  Hillerød", Score = "2 - 2", ImageURL = "http://bkfrem.dk/images/hill_2.jpg" });
        }
    }
}
