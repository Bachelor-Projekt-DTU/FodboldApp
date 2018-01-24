using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    class EventModel : RealmObject
    {
        public string ImageURL { get; set; }
        public string PlayerName { get; set; }
        public int Team { get; set; }
    }
}
