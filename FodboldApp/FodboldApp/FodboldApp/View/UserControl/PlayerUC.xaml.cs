using FodboldApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View.UserControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayerUC : Grid
	{
		public PlayerUC ()
		{
			InitializeComponent ();
		}

        async void Players_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayerDescription());

            Console.WriteLine("Players_Tapped");
        }
    }
}
