using FodboldApp.Customs;
using FodboldApp.View;

namespace FodboldApp.Stack
{
    public class CustomStack
    {
        public CustomNavigationPage NewsContent;
        public CustomNavigationPage PlayerContent;
        public CustomNavigationPage MatchContent;
        public CustomNavigationPage LeagueTableContent;
        public CustomNavigationPage HistoryContent;

        public static CustomStack Instance { get; private set; } = new CustomStack();

        //keeps one navigationpage per tab to save user's position when he chooses another tab
        public CustomStack()
        {
            NewsContent = new CustomNavigationPage(new News());
            PlayerContent = new CustomNavigationPage(new Players());
            MatchContent = new CustomNavigationPage(new Matches());
            LeagueTableContent = new CustomNavigationPage(new LeagueTable());
            HistoryContent = new CustomNavigationPage(new History());
        }

        internal static void ResetStack()
        {
            Instance = new CustomStack();
        }
    }
}
