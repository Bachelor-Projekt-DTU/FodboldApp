using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    public class EventModel : RealmObject
    {
        public MatchModel Match { get; set; }
        public string ImageURL { get; set; }
        public string PlayerName { get; set; }
        public int Team { get; set; }
        public string Type { get; set; }
    }
}
