using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    public class OverHundredGamesModel : RealmObject
    {
        [Ignored]
        private int _index { get; set; }
        [Ignored]
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                RaisePropertyChanged(nameof(Index));
            }
        }
        public string PlayerId { get; set; }
        public string Name { get; set; }
        public string Period { get; set; }
        public int Games { get; set; }
    }
}
