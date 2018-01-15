using FodboldApp.Pages;
using FodboldApp.Stack;
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
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            await CustomStack.Instance.NewsContent.Navigation.PushAsync(new NewsPage());
            await Navigation.PushAsync(new NewsPage());
        }
    }
}