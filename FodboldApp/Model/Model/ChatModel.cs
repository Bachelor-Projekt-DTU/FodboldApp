using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    public class ChatModel : RealmObject
    {
        public string MatchID { get; set; }
        public bool Admin { get; set; }
        public string Content { get; set; }
    }
}
