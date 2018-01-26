using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class MatchPageVM : INotifyPropertyChanged
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

        public string Date { get; private set; }
        public string Teams { get; private set; }
        public ICommand SendCommentCommand { get; set; }

        private string _score { get; set; }
        public string Score {
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
                    Console.WriteLine("why u not working "+LabelIsVisible);
                    Console.WriteLine("teksten "+UserComment);           
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

        private ObservableCollection<object> _eventList { get; set; } = new ObservableCollection<object>();
        public ObservableCollection<object> EventList
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

        private ObservableCollection<object> _commentList { get; set; } = new ObservableCollection<object>();
        public ObservableCollection<object> CommentList
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
            CommentList.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = _userComment, UserName = "Peter Petersen" });
            foreach (CommentModel Comment in CollectionList[1].CollectionList)
            {
                Console.WriteLine(Comment.UserComment);
            }
        }

        public MatchPageVM()
        {
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "OSB. Peteresen", Team = 4 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "OSB. Peteresen", Team = 4 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
             Score = "2 - 2";
            Teams = "BK FREM - Hillerød";
            _commentList.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Virkelig godt skudt ind!", UserName = "Peter Petersen" });
            _commentList.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Mååål", UserName = "Hans Hansen" });
            _commentList.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Sådan! Så fik vi det ene point", UserName = "Kasper Kaspersen" });
            _collectionList.Add(new ObservableCollectionsModel { CollectionList = EventList, ListSwitch = true });
            _collectionList.Add(new ObservableCollectionsModel { CollectionList = CommentList, ListSwitch = false });

            SendCommentCommand = new Command(OnSendTapped);
        }
    }
}
