using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FodboldApp.Model
{
    public class MatchModel : RealmObject
    {
        public string Id { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public string ImageURL { get; set; } = "http://bkfrem.dk/images/hill_2.jpg";
        public override bool Equals(object obj)
        {
            MatchModel match = (MatchModel)obj;
            return Team1 == match.Team1 && Team2 == match.Team2 && Score1 == match.Score1 && Score2 == match.Score2 && ImageURL == match.ImageURL;
        }
    }

}