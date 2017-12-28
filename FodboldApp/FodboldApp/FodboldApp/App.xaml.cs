using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FodboldApp
{
    public partial class App : Application
    {
        public static NavigationPage Navigation = null;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
            await Navigation.PopAsync();
        }

        public async void Login(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
