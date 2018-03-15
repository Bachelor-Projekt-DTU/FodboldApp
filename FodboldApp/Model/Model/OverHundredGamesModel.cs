using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    class OverHundredGamesModel : RealmObject
    {
        [Ignored]
        public int Index { get; set; }
        [PrimaryKey]
        public string PlayerId { get; set; }
        public string Name { get; set; }
        public string Period { get; set; }
        public int Games { get; set; }
    }
}
