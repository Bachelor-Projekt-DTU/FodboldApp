using System.Linq;
using FodboldApp.Globals;
using FodboldApp.Model;
using FodboldApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OverFiftyGoals : ContentPage
	{
        protected override bool OnBackButtonPressed()
        {
            HeaderVM.BackButtonPressed();
            return true;
        }

        public OverFiftyGoals ()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new OverFiftyGoalsVM();
        }
    }
}