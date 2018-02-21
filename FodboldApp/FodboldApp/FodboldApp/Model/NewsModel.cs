using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    class NewsModel : RealmObject
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Resume { get; set; }
        public string ImageURL { get; set; }
        public string Text { get; set; }
    }
}
