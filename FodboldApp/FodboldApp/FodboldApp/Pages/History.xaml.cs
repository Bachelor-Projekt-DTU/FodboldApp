using FodboldApp.Pages;
using System;
using Xamarin.Forms;

namespace FodboldApp
{
	public partial class History : ContentPage
	{
        public History()
        {
            InitializeComponent();
        }
        async void FormerPlayers_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            await ((App)Application.Current).MainPage.Navigation.PushAsync(new Former_Players());
        }
        async void POTY_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            await ((App)Application.Current).MainPage.Navigation.PushAsync(new POTY());
        }
    }
}
