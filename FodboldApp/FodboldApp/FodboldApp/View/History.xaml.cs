using FodboldApp.Stack;
using FodboldApp.View;
using System;
using Xamarin.Forms;

namespace FodboldApp
{
    partial class History : ContentPage
	{
        HistoricalStandingVM historicalStandingVM;

        public History()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void FormerPlayers_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");



            //await NavigationStack.PushAsync(new FormerPlayers());

            await CustomStack.Instance.HistoryContent.Navigation.PushAsync(new FormerPlayers());
            await Navigation.PushAsync(new FormerPlayers());
        }
        async void POTY_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            await CustomStack.Instance.HistoryContent.Navigation.PushAsync(new POTY());
            await Navigation.PushAsync(new POTY());
        }
        async void OverFiftyGoals_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            await CustomStack.Instance.HistoryContent.Navigation.PushAsync(new FormerPlayers());
            await Navigation.PushAsync(new OverFiftyGoals());
        }

        async void OverHundredGames_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            await CustomStack.Instance.HistoryContent.Navigation.PushAsync(new OverHundredGames());
            await Navigation.PushAsync(new OverHundredGames());
        }
        async void HistoricalStandings_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");

            await CustomStack.Instance.HistoryContent.Navigation.PushAsync(new HistoricalStandings());
            await Navigation.PushAsync(new HistoricalStandings());
        }
    }
}
