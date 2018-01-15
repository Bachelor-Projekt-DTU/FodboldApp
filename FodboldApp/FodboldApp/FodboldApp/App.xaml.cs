using DLToolkit.Forms.Controls;
using FodboldApp.View;
using FodboldApp.ViewModel;
using System;

using Xamarin.Forms;

namespace FodboldApp
{
    public partial class App : Application
    {
        HeaderViewModel vm;

        public App()
        {
            InitializeComponent();
            FlowListView.Init();


            MainPage = new NavigationPage(new FrontPage());

            vm = new HeaderViewModel();

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

        public async void OnBackButtonPressed(object sender, EventArgs e)
        {
            await ((NavigationPage)MainPage).PopAsync();
        }

        public async void Login(object sender, EventArgs e)
        {
            await ((App)Current).MainPage.Navigation.PushAsync(new Login());
        }



        //NavigationPage CurrentContext;
        //CustomStack stack = CustomStack.Instance;

        void ResetIconTint()
        {
            //tintedImage_News.TintColor = Color.FromRgb(84, 84, 84);
            //tintedImage_Players.TintColor = Color.FromRgb(84, 84, 84);
            //tintedImage_Matches.TintColor = Color.FromRgb(84, 84, 84);
            //tintedImage_Tournament.TintColor = Color.FromRgb(84, 84, 84);
            //tintedImage_History.TintColor = Color.FromRgb(84, 84, 84);
        }

        void NewsTapped(object sender, EventArgs e)
        {
            vm.NewsTap();
            //ResetIconTint();
            //var page = new News();
            //MainPage = stack.NewsContent;
            //((NavigationPage)MainPage).PopAsync(page);
            //MainViewModel.ButtonPressPage(0);
            //CurrentContext = stack.NewsContent;
            //tintedImage_News.TintColor = Color.FromRgb(49, 91, 170);
        }

        void PlayersTapped(object sender, EventArgs e)
        {
            vm.PlayerTap();
            //ResetIconTint();
            ////var page = new Players();
            ////PlaceHolder.Content = page.Content;
            //MainViewModel.ButtonPressPage(1);
            //CurrentContext = stack.PlayerContent;
            //tintedImage_Players.TintColor = Color.FromRgb(49, 91, 170);
        }

        void MatchesTapped(object sender, EventArgs e)
        {
            vm.MatchTap();
            //ResetIconTint();
            ////var page = new Matches();
            ////PlaceHolder.Content = page.Content;
            //MainViewModel.ButtonPressPage(2);
            //CurrentContext = stack.MatchContent;
            //tintedImage_Matches.TintColor = Color.FromRgb(49, 91, 170);
        }

        void TournamentTapped(object sender, EventArgs e)
        {
            vm.TournamentTap();
            //ResetIconTint();
            ////var page = new Tournament();
            ////PlaceHolder.Content = page.Content;
            //MainViewModel.ButtonPressPage(3);
            //CurrentContext = stack.TournamentContent;
            //tintedImage_Tournament.TintColor = Color.FromRgb(49, 91, 170);
        }

        void HistoryTapped(object sender, EventArgs e)
        {
            vm.HistoryTap();
            //ResetIconTint();
            ////var page = new History();
            ////PlaceHolder.Content = page.Content;
            //MainViewModel.ButtonPressPage(4);
            //CurrentContext = stack.HistoryContent;
            //tintedImage_History.TintColor = Color.FromRgb(49, 91, 170);
        }
    }
}
