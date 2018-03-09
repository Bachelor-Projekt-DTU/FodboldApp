using FodboldApp.Model;
using Realms;
using System;
using System.ComponentModel;
using System.Linq;

namespace FodboldApp.ViewModel
{
    class MatchHeaderVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Realm _realm;
        
        public string DateTime
        {
            get
            {
                var temp0 = HeaderMatch.DateTime.Split(' ');
                var temp1 = temp0[0].Split('-');
                return temp1[2] + "-" + temp1[1] + "-" + temp1[0] + " " + temp0[1];
            }
        }
        public string Location { get; private set; }
        public string Division { get; private set; }

        public bool Live
        {
            get
            {
                return HeaderMatch.Status == "Live";
            }
        }

        public string Scores
        {
            get
            {
                return "2-2"/* Match.Scores*/;
            }
        }

        public string Teams
        {
            get
            {
                return HeaderMatch.Team1 + "-" + HeaderMatch.Team2;
            }
        }

        private HeaderMatchModel _headerMatch { get; set; } = new HeaderMatchModel();
        public HeaderMatchModel HeaderMatch
        {
            get { return _headerMatch; }
            set
            {
                _headerMatch = value;
                OnPropertyChanged(nameof(HeaderMatch));
                OnPropertyChanged(nameof(Teams));
                OnPropertyChanged(nameof(DateTime));
                OnPropertyChanged(nameof(Live));
            }
        }

        private async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("futureMatches");
            HeaderMatch = _realm.All<HeaderMatchModel>().First();
            Console.WriteLine("STAPLE GUN" + _realm.All<HeaderMatchModel>().AsRealmCollection().Count);
        }

        public MatchHeaderVM()
        {
            SetupRealm();
            Location = "Skovshoved IP";
            Division = "2. Division Pulje 1";
        }
    }
}
