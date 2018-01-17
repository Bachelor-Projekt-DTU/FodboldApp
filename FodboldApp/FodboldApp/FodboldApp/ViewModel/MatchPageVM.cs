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

        private ObservableCollection<EventData> _eventList { get; set; } = new ObservableCollection<EventData>();
        public ObservableCollection<EventData> EventList
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

        public MatchPageVM()
        {
            _eventList.Add(new EventData { ImageURL = "https://icon-icons.com/icons2/553/PNG/512/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            _eventList.Add(new EventData { ImageURL = "https://icon-icons.com/icons2/553/PNG/512/footbal_icon-icons.com_53569.png", PlayerName = "OSB. Peteresen", Team = 4 });
            _eventList.Add(new EventData { ImageURL = "https://icon-icons.com/icons2/553/PNG/512/footbal_icon-icons.com_53569.png", PlayerName = "H. Horani", Team = 0 });
            Score = "2 - 1";
            Teams = "Hadis Hold - Oliviers Hold";
        }
    }
}
