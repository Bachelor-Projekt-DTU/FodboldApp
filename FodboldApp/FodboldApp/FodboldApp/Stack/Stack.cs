using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.Stack
{
    class Stack
    {
        NavigationPage NewsContent;
        NavigationPage PlayerContent;
        NavigationPage MatchContent;
        NavigationPage TournamentContent;
        NavigationPage HistoryContent;

        public Stack()
        {
            NewsContent = new NavigationPage(new News());
            PlayerContent = new NavigationPage(new Players());
            MatchContent = new NavigationPage(new Matches());
            TournamentContent = new NavigationPage(new Tournament());
            HistoryContent = new NavigationPage(new History());
        }
    }
}
