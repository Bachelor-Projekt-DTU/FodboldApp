using FodboldApp.Stack;
using FodboldApp.View;
using System;

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
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void News_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            await CustomStack.Instance.NewsContent.Navigation.PushAsync(new NewsPage());
            await Navigation.PushAsync(new NewsPage());
        }
    }
}