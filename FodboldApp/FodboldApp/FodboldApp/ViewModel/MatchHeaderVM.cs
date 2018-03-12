using FodboldApp.Model;
using Realms;
using System;
using System.ComponentModel;
using System.Linq;
using Com.OneSignal;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;

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

        public ICommand SubscribeToNotifications { get; set; }

        private string NotificationTag = "SubscribedToMatch";
        private bool _isSubscribedtoNotifications { get; set; }
        public bool IsSubscribedtoNotifications
        {
            get
            {
                return _isSubscribedtoNotifications;
            }
            set
            {
                _isSubscribedtoNotifications = value;
                OnPropertyChanged(nameof(IsSubscribedtoNotifications));
            }
        }

        private Color SelectedColor = Color.FromHex("#ffc200");
        private Color UnSelectedColor = Color.Gray;
        private Color _bellColor { get; set; }
        public Color BellColor
        {
            get
            {
                return _bellColor;
            }
            set
            {
                _bellColor = value;
                OnPropertyChanged(nameof(BellColor));
            }
        }

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

        private void SubscribeToMatch()
        {
            if (IsSubscribedtoNotifications)
            {
                BellColor = UnSelectedColor;
                OneSignal.Current.DeleteTag(NotificationTag);
            }
            else
            {
                BellColor = SelectedColor;
                OneSignal.Current.SendTag(NotificationTag, HeaderMatch.Id);
            }
            IsSubscribedtoNotifications = !IsSubscribedtoNotifications;
        }

        public MatchHeaderVM()
        {
            SetupRealm();
            SubscribeToNotifications = new Command(SubscribeToMatch);
            OneSignal.Current.GetTags(InitBellColor);
        }

        private void InitBellColor(Dictionary<string, object> tags)
        {
            if (tags !=null && tags.ContainsKey(NotificationTag)) BellColor = SelectedColor;
            else BellColor = UnSelectedColor;
        }
    }
}
