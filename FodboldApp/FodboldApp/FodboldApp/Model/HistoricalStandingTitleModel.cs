using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    public class HistoricalStandingTitleModel : RealmObject
    {
        public string Title { get; set; }
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
