using FodboldApp.View;
using FodboldApp.ViewModel;
using System;
using Xamarin.Forms;

namespace FodboldApp
{
	public partial class History : ContentPage
	{
        HistoricalStandingVM historicalStandingVM;

        public History()
        {
            InitializeComponent();
            historicalStandingVM = new HistoricalStandingVM();
        }
        async void FormerPlayers_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            await ((App)Application.Current).MainPage.Navigation.PushAsync(new FormerPlayers());
        }
        async void POTY_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            await ((App)Application.Current).MainPage.Navigation.PushAsync(new POTY());
        }
        async void OverFiftyGoals_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            await ((App)Application.Current).MainPage.Navigation.PushAsync(new OverFiftyGoals());
        }

        async void OverHundredGames_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            await ((App)Application.Current).MainPage.Navigation.PushAsync(new OverHundredGames());
        }
        async void HistoricalStandings_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            ((App)Application.Current).MainPage.BindingContext = historicalStandingVM;
            await ((App)Application.Current).MainPage.Navigation.PushAsync(new HistoricalStandings());
        }
    }
}
