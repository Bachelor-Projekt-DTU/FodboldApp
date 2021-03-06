﻿using FodboldApp.Model;
using Realms;
using System;
using System.ComponentModel;
using System.Linq;
using Com.OneSignal;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
                if (HeaderMatch.DateTime != null)
                {
                    var temp0 = HeaderMatch.DateTime.Split(' ');
                    var temp1 = temp0[0].Split('-');
                    return temp1[2] + "-" + temp1[1] + "-" + temp1[0] + " " + temp0[1];
                }
                return "Ingen fremtidige kampe";
            }
        }

        public string Id { get; set; }

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
                if (HeaderMatch.Team1 != null) return HeaderMatch.Team1 + "-" + HeaderMatch.Team2;
                return "";
            }
        }

        private HeaderMatchModel _headerMatch { get; set; } = new HeaderMatchModel();
        public HeaderMatchModel HeaderMatch
        {
            get { return _headerMatch; }
            set
            {
                _headerMatch = value;
                Id = HeaderMatch.Id;
                OneSignal.Current.GetTags(InitBellColor);
                OnPropertyChanged(nameof(HeaderMatch));
                OnPropertyChanged(nameof(Teams));
                OnPropertyChanged(nameof(DateTime));
                OnPropertyChanged(nameof(Live));
            }
        }

        private IQueryable<HeaderMatchModel> _futureMatchList { get; set; }
        private IQueryable<HeaderMatchModel> FutureMatchList
        {
            get
            {

                return _futureMatchList;
            }
            set
            {
                _futureMatchList = value;
                if (_futureMatchList.Count() > 0)
                {
                    HeaderMatch = _futureMatchList.First();
                    Id = HeaderMatch.Id;
                }
            }
        }

        private async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("futureMatches");
            FutureMatchList = _realm.All<HeaderMatchModel>();
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

        private void InitBellColor(Dictionary<string, object> tags)
        {
            if (tags != null && tags.ContainsKey(NotificationTag) && (string)tags[NotificationTag] == Id) BellColor = SelectedColor;
            else BellColor = UnSelectedColor;
        }

        private async void CheckForUpdate()
        {
            int oldCount = 0;
            while (true)
            {
                if (FutureMatchList != null && FutureMatchList.Count() != oldCount)
                {
                    oldCount = FutureMatchList.Count();
                    if (!HeaderMatch.Equals(FutureMatchList.First()))
                    {
                        _realm.Write(() =>
                        {
                            int i = 0;
                            HeaderMatch = FutureMatchList.First();
                        });
                    }
                }
                await Task.Delay(500);
            }
        }

        public MatchHeaderVM()
        {
            SetupRealm();
            SubscribeToNotifications = new Command(SubscribeToMatch);
            CheckForUpdate();
        }
    }
}
