using Realms;
using System.ComponentModel;

namespace FodboldApp
{
    class ClubModel : RealmObject
    {
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
