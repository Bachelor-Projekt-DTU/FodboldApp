using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model
{
    public class HeaderMatchModel : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string DateTime { get; set; }
        public string Status { get; set; }
    }
}
