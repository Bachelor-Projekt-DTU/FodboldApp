using Realms;
using System.ComponentModel;

namespace FodboldApp
{
    class ClubModel : RealmObject
    {
        [PrimaryKey]
        public string ClubName { get; set; }
        [Ignored]
        public bool _selected { get; set; } = false;
        [Ignored]
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
