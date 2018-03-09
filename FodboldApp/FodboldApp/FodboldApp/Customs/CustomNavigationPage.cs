using Xamarin.Forms;

namespace FodboldApp.Customs
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(Page page) : base(page)
        {
            this.BackgroundColor = Globals.ColoringLogic.GetColor(1);
        }
    }
}
