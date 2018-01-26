using FodboldApp.Globals;
using FodboldApp.Model;
using FodboldApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormerPlayers : ContentPage
	{
        protected override bool OnBackButtonPressed()
        {
            HeaderVM.BackButtonPressed();
            return true;
        }

        public FormerPlayers ()
		{
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new FormerPlayersVM();
        }
    }
}