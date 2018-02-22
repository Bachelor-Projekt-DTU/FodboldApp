using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Realms.Sync;
using System.Linq;

namespace FodboldApp.ViewModel
{
    class MatchPageVM : INotifyPropertyChanged
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

        private MatchModel _match { get; set; } = new MatchModel { Team1 = "Loading Error", Team2 = "Loading Error" };
        public MatchModel Match
        {
            get { return _match; }
            set
            {
                _match = value;
                UpdateLists();
                OnPropertyChanged(nameof(Match));
                OnPropertyChanged(nameof(Teams));
                OnPropertyChanged(nameof(Scores));
                OnPropertyChanged(nameof(EventList));
                OnPropertyChanged(nameof(CommentList));
            }
        }
        public string Date { get; private set; }
        public ICommand SendCommentCommand { get; set; }
        public string Teams { get { return Match.Teams; } }
        public string Scores
        { get { return Match.Scores; } }

        private bool _labelIsVisible { get; set; } = true;
        public bool LabelIsVisible
        {
            get
            {
                return _labelIsVisible;
            }
            set
            {
                _labelIsVisible = value;
                OnPropertyChanged(nameof(LabelIsVisible));
            }
        }

        private string _userComment { get; set; }
        public string UserComment
        {
            get
            {
                return _userComment;
            }
            set
            {
                _userComment = value;

                if (_userComment.Length > 0)
                {
                    LabelIsVisible = false;
                }
                else
                {
                    LabelIsVisible = true;
                }
                OnPropertyChanged(nameof(UserComment));
            }
        }

        private ObservableCollection<ObservableCollectionsModel> _collectionList { get; set; } = new ObservableCollection<ObservableCollectionsModel>();
        public ObservableCollection<ObservableCollectionsModel> CollectionList
        {
            get
            {
                return _collectionList;
            }
            set
            {
                _collectionList = value;
                OnPropertyChanged(nameof(CollectionList));
            }
        }

        private IQueryable<object> _eventList { get; set; }
        public IQueryable<object> EventList
        {
            get
            {
                return _eventList;
            }
            set
            {
                _eventList = value;
                OnPropertyChanged(nameof(EventList));
            }
        }

        private IQueryable<object> _commentList { get; set; }
        public IQueryable<object> CommentList
        {
            get
            {
                return _commentList;
            }
            set
            {
                _commentList = value;
                OnPropertyChanged(nameof(CommentList));
            }
        }

        void OnSendTapped()
        {
            _realm.Write(() =>
            {
                _realm.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = this.UserComment, UserName = "Peter Petersen" });
            });
            CommentList = _realm.All<CommentModel>();
            foreach (CommentModel Comment in CollectionList[1].CollectionList)
            {
                Console.WriteLine(Comment.UserComment);
            }
        }

        private void UpdateLists()
        {
            try
            {
                Console.WriteLine("STAPLE GUN: " + EventList.Count());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //EventList = _realm.All<EventModel>();
            //Teams = "BK FREM - Hillerød";
            

        }

        private async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("matches");
            EventList = _realm.All<EventModel>().Where(data => data.Match == Match);
            CommentList = _realm.All<CommentModel>();
            CollectionList.Add(new ObservableCollectionsModel { CollectionList = EventList, ListSwitch = true });
            CollectionList.Add(new ObservableCollectionsModel { CollectionList = CommentList, ListSwitch = false });
            //var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            //SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/matches"));
            //_realm = Realm.GetInstance(config);
            //int index = 0;
            //_realm.Write(() =>
            //{
            //    _realm.RemoveAll();
            //    _realm.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            //    _realm.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "OSB. Peteresen", Team = 4 });
            //    _realm.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            //    _realm.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "OSB. Peteresen", Team = 4 });
            //    _realm.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            //    _realm.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            //    _realm.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            //    _realm.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Virkelig godt skudt ind!", UserName = "Peter Petersen" });
            //    _realm.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Mååål", UserName = "Hans Hansen" });
            //    _realm.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Sådan! Så fik vi det ene point", UserName = "Kasper Kaspersen" });
            //});
            //_realm.Dispose();
            //UpdateLists();
            //Console.WriteLine("okokokok" +EventList.Count());
        }

        public MatchPageVM()
        {
            SetupRealm();
            SendCommentCommand = new Command(OnSendTapped);
        }
    }
}
