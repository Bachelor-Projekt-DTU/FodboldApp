using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    class POTYModel : RealmObject
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public int Index { get; set; }
    }
}
