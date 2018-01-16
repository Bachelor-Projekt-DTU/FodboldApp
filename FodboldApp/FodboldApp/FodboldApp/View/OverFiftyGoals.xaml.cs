using System.Linq;
using FodboldApp.Colorization;
using FodboldApp.Model;
using FodboldApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OverFiftyGoals : ContentPage
	{
		public OverFiftyGoals ()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new OverFiftyGoalsVM();
        }
    }
}