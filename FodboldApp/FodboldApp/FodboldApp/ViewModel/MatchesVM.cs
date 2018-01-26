using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using FodboldApp.Model;
using Realms;

namespace FodboldApp.ViewModel
{
    class MatchesVM : INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private IEnumerable<MatchModel> _matchList { get; set; } = new ObservableCollection<MatchModel>();
        public IEnumerable<MatchModel> MatchList
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
            _realm = Realm.GetInstance();
            _realm.Write(() =>
            {
                _realm.Add(new MatchModel { Teams = "BK FREM  -  Hillerød", Score = "2 - 2", ImageURL = "http://bkfrem.dk/images/hill_2.jpg" });
                _realm.Add(new MatchModel { Teams = "BK FREM  -  Hillerød", Score = "2 - 2", ImageURL = "http://bkfrem.dk/images/hill_2.jpg" });
            });
            _matchList = _realm.All<MatchModel>();
        }
    }
}
