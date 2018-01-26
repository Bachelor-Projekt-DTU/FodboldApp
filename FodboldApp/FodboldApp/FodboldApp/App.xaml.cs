using DLToolkit.Forms.Controls;
using FodboldApp.View;
using FodboldApp.ViewModel;
using Realms;
using System;
using Xamarians.GoogleLogin.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(xamlCompilationOptions: XamlCompilationOptions.Compile)]

namespace FodboldApp
{
    public partial class App : Application
    {
        HeaderVM vm;
        Realm _realm = Realm.GetInstance();

        public App()
        {
            _realm.Write(() =>
            {
                _realm.RemoveAll();
            });

            InitializeComponent();

            vm = ViewModelLocator.HeaderVM;

            BindingContext = vm;

            FlowListView.Init();

            MainPage = new NavigationPage(new FrontPage());

            NavigationPage.SetHasNavigationBar(this, false);
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
        public async void LoginOut(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                // Sign out from Google+ on iOS
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                var result = await DependencyService.Get<IGoogleLogin>().SignOut();
                if (result.IsSuccess)
                {
                    Console.WriteLine("Logget ud");
                    ViewModelLocator.HeaderVM.IsUserLoggedIn = false;
                }
            }
        }
    }
}
