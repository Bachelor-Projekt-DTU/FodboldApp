using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Player_Description : ContentPage
	{
		public Player_Description ()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}