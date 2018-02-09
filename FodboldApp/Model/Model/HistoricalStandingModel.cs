using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.Model
{
    public class HistoricalStandingModel : RealmObject
    {
        public string TournamentName { get; set; }
        public string Year { get; set; }
        public string Standing { get; set; }
        public string Games { get; set; }
        public string Record { get; set; }
        public string Points { get; set; }
    }
}
