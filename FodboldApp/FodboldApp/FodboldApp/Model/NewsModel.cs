using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    public class NewsModel : RealmObject
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public string Resume
        {
            get
            {
                if (Text.Length < 200) return Text;
                return Text.Substring(0, 200) + "...";
            }
        }
        public string ImageURL { get; set; }
        public string ArticleId { get; set; }
    }
}
