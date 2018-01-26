using Realms;
using System.ComponentModel;

namespace FodboldApp
{
    class ClubModel : RealmObject
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string name)
        //{
        //    var handler = PropertyChanged;

        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(name));
        //    }
        //}

        public string ClubName { get; set; }
        public bool _selected { get; set; } = false;
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                RaisePropertyChanged(nameof(Selected));
            }
        }
    }
}
