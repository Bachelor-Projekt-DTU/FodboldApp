using FodboldApp.View;
using Xamarin.Forms;

namespace FodboldApp.Stack
{
    public class CustomStack
    {
        public NavigationPage NewsContent;
        public NavigationPage PlayerContent;
        public NavigationPage MatchContent;
        public NavigationPage TournamentContent;
        public NavigationPage HistoryContent;

        public static CustomStack Instance { get; } = new CustomStack();

        public CustomStack()
        {
            NewsContent = new NavigationPage(new News());
            PlayerContent = new NavigationPage(new Players());
            MatchContent = new NavigationPage(new Matches());
            TournamentContent = new NavigationPage(new Tournament());
            HistoryContent = new NavigationPage(new History());
        }
    }
}
