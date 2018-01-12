using FodboldApp.Pages;
using FodboldApp.Stack;
using FodboldApp.ViewModel;
using System;
using Xamarin.Forms;

namespace FodboldApp
{
	partial class History : ContentPage
	{
        //NavigationPage NavigationStack = CustomStack.Instance.HistoryContent;

        public History()
        {
            InitializeComponent();
        }
        async void FormerPlayers_Tapped(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("WE ON IT");



            //await NavigationStack.PushAsync(new FormerPlayers());

            await Navigation.PushAsync(new FormerPlayers());
            MainViewModel.ButtonPressPage(4);
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

            await ((App)Application.Current).MainPage.Navigation.PushAsync(new HistoricalStandings());
        }
    }
}
