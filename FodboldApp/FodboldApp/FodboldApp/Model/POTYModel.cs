using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    public class POTYModel : RealmObject
    {
        [Ignored]
        public int Index { get; set; }
        public string PlayerId { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
    }
}
