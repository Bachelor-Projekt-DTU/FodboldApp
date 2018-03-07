using FodboldApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LeagueTable : ContentPage
	{

        public LeagueTable()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}