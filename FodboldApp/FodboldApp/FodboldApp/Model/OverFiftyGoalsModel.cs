using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    class OverFiftyGoalsModel : RealmObject
    {    
        public string Name { get; set; }
        public string Period { get; set; }
        public string Goals_Games { get; set; }
        public int Index { get; set; }
    }
}
