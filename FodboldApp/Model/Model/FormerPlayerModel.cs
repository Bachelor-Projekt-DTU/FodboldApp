using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    public class FormerPlayerModel : RealmObject
    {
        public string Player { get; set; }
        public int Index { get; set; }
    }
}
