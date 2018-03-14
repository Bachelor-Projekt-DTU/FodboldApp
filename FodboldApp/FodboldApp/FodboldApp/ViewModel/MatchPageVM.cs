using FodboldApp.Model;
using Realms;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using FodboldApp.Globals;

namespace FodboldApp.ViewModel
{
    class MatchPageVM : INotifyPropertyChanged
    {
        public static Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
                    SendButtonIsVisible = true;
                }
                else
                {
                    LabelIsVisible = true;
                    SendButtonIsVisible = false;
                }
                OnPropertyChanged(nameof(UserComment));
            }
        }

        private int _pagePosition { get; set; }
        public int PagePosition
        {
            get
            {
                return _pagePosition;
            }
            set
            {
                _pagePosition = value;
                OnPropertyChanged(nameof(PagePosition));
            }
        }
        
        private bool _sendButtonIsVisible { get; set; }
        public bool SendButtonIsVisible
        {
            get
            {
                return _sendButtonIsVisible;
            }
            set
            {
                _sendButtonIsVisible = value;
                OnPropertyChanged(nameof(SendButtonIsVisible));
            }
        }

        private ObservableCollection<ObservableCollectionsVM> _collectionList { get; set; } = new ObservableCollection<ObservableCollectionsVM>();
        public ObservableCollection<ObservableCollectionsVM> CollectionList
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
                    _realm.Add(new CommentModel {MatchId = Match.Id, UserId = CurrentUser.user.Id, ImageURL = CurrentUser.user.Picture, UserComment = this.UserComment, UserName = CurrentUser.user.Name, IsVerified = CurrentUser.IsAdmin});
                });
            CommentList = _realm.All<CommentModel>();
            foreach (CommentModel Comment in CollectionList[1].CollectionList)
            {
                Console.WriteLine(Comment.UserComment);
            }
            UserComment = String.Empty;
            Console.WriteLine("HHHHH " + PagePosition);
            if (PagePosition == 0) PagePosition = 1;
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
        }

        private async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("matches");
            EventList = _realm.All<EventModel>().Where(data => data.Match == Match);
            CommentList = _realm.All<CommentModel>().Where(data => data.MatchId == Match.Id);
            CollectionList.Add(new ObservableCollectionsVM { CollectionList = EventList, ListSwitch = true });
            CollectionList.Add(new ObservableCollectionsVM { CollectionList = CommentList, ListSwitch = false });
        }

        public MatchPageVM()
        {
            SetupRealm();
            SendCommentCommand = new Command(OnSendTapped);
        }
    }
}
