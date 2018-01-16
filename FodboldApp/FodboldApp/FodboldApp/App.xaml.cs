using DLToolkit.Forms.Controls;
using FodboldApp.Stack;
using FodboldApp.View;
using FodboldApp.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(xamlCompilationOptions: XamlCompilationOptions.Compile)]

namespace FodboldApp
{
    public partial class App : Application
    {
        HeaderVM vm;

        public App()
        {
            InitializeComponent();
            FlowListView.Init();


            MainPage = new NavigationPage(new FrontPage());

            vm = new HeaderVM();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = vm;
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void OnBackButtonPressed(object sender, EventArgs e)
        {
            HeaderVM.BackButtonPressed();
        }

        public async void Login(object sender, EventArgs e)
        {
            await ((App)Current).MainPage.Navigation.PushAsync(new Login());
        }


        void NewsTapped(object sender, EventArgs e)
        {
            vm.NewsTap();
        }

        void PlayersTapped(object sender, EventArgs e)
        {
            vm.PlayerTap();
        }

        void MatchesTapped(object sender, EventArgs e)
        {
            vm.MatchTap();
        }

        void TournamentTapped(object sender, EventArgs e)
        {
            vm.TournamentTap();
        }

        void HistoryTapped(object sender, EventArgs e)
        {
            vm.HistoryTap();
        }
    }
}
