using Com.OneSignal;
using DLToolkit.Forms.Controls;
using FodboldApp.Globals;
using FodboldApp.ViewModel;
using Realms;
using Realms.Sync;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(xamlCompilationOptions: XamlCompilationOptions.Compile)]

namespace FodboldApp
{
    public partial class App : Application
    {
        HeaderVM vm;
        public static SearchBar Searchbar;

        public App()
        {
            SetupRealm();

            OneSignal.Current.StartInit("84ec0128-74a1-40f9-89b1-35e35da35acd")
                  .EndInit();

            InitializeComponent();

            var temp = this.FindByName<ControlTemplate>("Template");

            vm = ViewModelLocator.HeaderVM;

            BindingContext = vm;

            FlowListView.Init();
            try
            {
                if (Current.Properties.ContainsKey("IsUserLoggedIn"))
                {
                    if ((string)Current.Properties["LoginType"] == "Google")
                        GooglePlusAutoLogin();

                    else if ((string)Current.Properties["LoginType"] == "Facebook")
                        FacebookAutoLogin();
                }
            }
            catch (Exception)
            {
                Current.Properties.Remove("IsUserLoggedIn");
            }

            MainPage = new NavigationPage(new FrontPage());

            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void SetupRealm()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("StandardUser", "12345", false), new Uri($"http://13.59.205.12:9080"));
            var config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/futureMatches"));
            Realm.GetInstance(config);
        }

        async void FacebookAutoLogin()
        {
            if (Current.Properties.ContainsKey("Token"))
            {
                ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
                CurrentUser.user.AccessToken = (string)Current.Properties["Token"];
                FacebookSingleton.Instance.GetUserInfoAsync();
            }
        }

        async void GooglePlusAutoLogin()
        {
            if (Current.Properties.ContainsKey("Token"))
            {
                ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
                CurrentUser.user.AccessToken = (string)Current.Properties["Token"];
                GooglePlusSingleton.Instance.GetUserInfoAsync();
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
    }
}
