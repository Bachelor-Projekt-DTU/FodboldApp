using FodboldApp.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{   
		public Login ()
		{
            BindingContext = ViewModel.ViewModelLocator.LoginVM;
            InitializeComponent();

            ((NavigationPage)Xamarin.Forms.Application.Current.MainPage).BarBackgroundColor = Globals.ColoringLogic.AppPrimary;
        }
	}
}