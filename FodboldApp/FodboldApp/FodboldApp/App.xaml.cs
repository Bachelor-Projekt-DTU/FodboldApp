using Com.OneSignal;
using DLToolkit.Forms.Controls;
using FodboldApp.Globals;
using FodboldApp.Interfaces;
using FodboldApp.Model;
using FodboldApp.View;
using FodboldApp.ViewModel;
using Realms;
using System;
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

            OneSignal.Current.StartInit("84ec0128-74a1-40f9-89b1-35e35da35acd")
                  .EndInit();

            InitializeComponent();

            vm = ViewModelLocator.HeaderVM;

            BindingContext = vm;

            FlowListView.Init();

            if (Current.Properties.ContainsKey("IsUserLoggedIn"))
            {
                if ((string)Current.Properties["LoginType"] == "Google")
                    GooglePlusAutoLogin();

                else if ((string)Current.Properties["LoginType"] == "Facebook")
                    FacebookAutoLogin();
            }

            MainPage = new NavigationPage(new FrontPage());

            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void FacebookAutoLogin()
        {
            if (Current.Properties.ContainsKey("Token"))
            {
                ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
                CurrentUser.user.AccessToken = (string)Current.Properties["Token"];
                await ViewModelLocator.FacebookService.GetNameAsync(CurrentUser.user.AccessToken);
                await ViewModelLocator.FacebookService.GetPictureAsync(CurrentUser.user.AccessToken);
            }
        }

        async void GooglePlusAutoLogin()
        {
            if (Current.Properties.ContainsKey("Token"))
            {
                Console.WriteLine((string)Current.Properties["Token"]);
                ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
                CurrentUser.user.AccessToken = (string)Current.Properties["Token"];
                await ViewModelLocator.GoogleService.GetNameAsync(CurrentUser.user.AccessToken);
                await ViewModelLocator.GoogleService.GetPictureAsync(CurrentUser.user.AccessToken);
            }
        }

        protected override void OnStart()
        {
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
        public void LogOut(object sender, EventArgs e)
        {
            ViewModelLocator.HeaderVM.IsUserLoggedIn = false;
            if (Current.Properties.ContainsKey("IsUserLoggedIn"))
            {
                Console.WriteLine("Logget af");
                Current.Properties.Remove("IsUserLoggedIn");
            }

            if (ViewModelLocator.HeaderVM.TypeOfLogin == HeaderVM.LoginType.Google)
            {
                DependencyService.Get<ILogOut>().LogOutGoogle();
                Current.Properties.Remove("Token");
                GooglePlusSingleton.Instance.RemoveToken();
                GooglePlusSingleton.Instance.ResetAuthentication();
                CurrentUser.user = new UserModel();
            }
            else if (ViewModelLocator.HeaderVM.TypeOfLogin == HeaderVM.LoginType.Facebook)
            {
                DependencyService.Get<ILogOut>().LogOutFB();
                Current.Properties.Remove("Token");
                FacebookSingleton.Instance.RemoveToken();
                FacebookSingleton.Instance.ResetAuthentication();
                CurrentUser.user = new UserModel();
            }
        }
    }
}
