using FodboldApp.Globals;
using System.Linq;
using Xamarin.Forms;
using FodboldApp.Model;
using Xamarin.Forms.Xaml;
using FodboldApp.ViewModel;

namespace FodboldApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class POTY : ContentPage
	{
        protected override bool OnBackButtonPressed()
        {
            HeaderVM.BackButtonPressed();
            return true;
        }

        public POTY ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new POTYVM();
        }
    }
}