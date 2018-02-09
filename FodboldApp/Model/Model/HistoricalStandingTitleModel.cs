using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    public class HistoricalStandingTitleModel : RealmObject
    {
        public string Title { get; set; }

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
