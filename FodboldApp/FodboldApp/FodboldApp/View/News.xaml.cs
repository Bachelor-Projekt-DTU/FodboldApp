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

        
    }
}