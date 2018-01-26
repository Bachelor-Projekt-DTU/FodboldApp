using FodboldApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
            BindingContext = new LoginVM();
            InitializeComponent();

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Globals.ColoringLogic.AppPrimary;
        }
	}
}