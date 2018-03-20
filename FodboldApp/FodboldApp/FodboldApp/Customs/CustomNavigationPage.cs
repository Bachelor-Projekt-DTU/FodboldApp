using Xamarin.Forms;

namespace FodboldApp.Customs
{
    //Class solely exists to change the backgroundcolor of our pages
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(Page page) : base(page)
        {
            this.BackgroundColor = Globals.ColoringLogic.GetColor(1);
        }
    }
}
