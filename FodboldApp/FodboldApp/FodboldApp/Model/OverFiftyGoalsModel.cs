using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    public class OverFiftyGoalsModel : RealmObject
    {    
        [Ignored]
        public int Index { get; set; }
        public string PlayerId { get; set; }
        public string Name { get; set; }
        public string Period { get; set; }
        public string Goals_Games { get; set; }
        public int Goals { get; set; }
    }
}
