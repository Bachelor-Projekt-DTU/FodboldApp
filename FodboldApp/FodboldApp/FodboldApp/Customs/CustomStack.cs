using System;
using FodboldApp.Customs;
using FodboldApp.View;
using Xamarin.Forms;

namespace FodboldApp.Stack
{
    public class CustomStack
    {
        public CustomNavigationPage NewsContent;
        public CustomNavigationPage PlayerContent;
        public CustomNavigationPage MatchContent;
        public CustomNavigationPage TournamentContent;
        public CustomNavigationPage HistoryContent;

        public static CustomStack Instance { get; private set; } = new CustomStack();

        public CustomStack()
        {
            NewsContent = new CustomNavigationPage(new News());
            PlayerContent = new CustomNavigationPage(new Players());
            MatchContent = new CustomNavigationPage(new Matches());
            TournamentContent = new CustomNavigationPage(new Tournament());
            HistoryContent = new CustomNavigationPage(new History());
        }

        internal static void ResetStack()
        {
            Instance = new CustomStack();
        }
    }
}
