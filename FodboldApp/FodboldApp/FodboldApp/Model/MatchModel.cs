using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    class MatchModel : RealmObject
    {
        public string Teams { get; set; }
        public string Score { get; set; }
        public string ImageURL { get; set; }
    }
}
