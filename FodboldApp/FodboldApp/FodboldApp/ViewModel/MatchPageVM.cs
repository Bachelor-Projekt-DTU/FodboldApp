using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
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
        public string Teams { get; private set; }

        private ObservableCollection<EventModel> _eventList { get; set; } = new ObservableCollection<EventModel>();
        public ObservableCollection<EventModel> EventList
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

        private ObservableCollection<CommentModel> _commentList { get; set; } = new ObservableCollection<CommentModel>();
        public ObservableCollection<CommentModel> CommentList
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

        public MatchPageVM()
        {
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "OSB. Peteresen", Team = 4 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "OSB. Peteresen", Team = 4 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventModel { ImageURL = "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            Score = "2 - 2";
            Teams = "BK FREM - Hillerød";
            _commentList.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Virkelig godt skudt ind!", UserName = "Peter Petersen" });
            _commentList.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Mååål", UserName = "Hans Hansen" });
            _commentList.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Sådan! Så fik vi det ene point", UserName = "Kasper Kaspersen" });
            _commentList.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Sådan! Så fik vi det ene point", UserName = "Kasper Kaspersen" });
            _commentList.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Sådan! Så fik vi det ene point", UserName = "Kasper Kaspersen" });
            _commentList.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Sådan! Så fik vi det ene point", UserName = "Kasper Kaspersen" });
            _commentList.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Sådan! Så fik vi det ene point", UserName = "Kasper Kaspersen" });
            _commentList.Add(new CommentModel { ImageURL = "https://icon-icons.com/icons2/37/PNG/96/name_user_3716.png", UserComment = "Sådan! Så fik vi det ene point", UserName = "Kasper Kaspersen" });
        }
    }
}
