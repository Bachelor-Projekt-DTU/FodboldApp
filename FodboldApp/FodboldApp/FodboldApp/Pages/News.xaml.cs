using FodboldApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class News : ContentPage
	{
		public News ()
		{
			InitializeComponent ();
		}

        async void News_Tapped(object sender, EventArgs e)
        {
            //var page = new NewsPage();
            System.Diagnostics.Debug.WriteLine("WE ON IT");
            //this.Content = page.Content;
            await Navigation.PushAsync(new Players());
        }
    }
}