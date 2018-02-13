using Com.OneSignal;
using DLToolkit.Forms.Controls;
using FodboldApp.Globals;
using FodboldApp.Interfaces;
using FodboldApp.Model;
using FodboldApp.View;
using FodboldApp.ViewModel;
using Realms;
using Realms.Sync;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(xamlCompilationOptions: XamlCompilationOptions.Compile)]

namespace FodboldApp
{
    public partial class App : Application
    {
        HeaderVM vm;
        Realm _realm;

        public App()
        {
            //SetupRealmAsync();

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

        public async Task SetupRealmAsync()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data"));
            _realm = Realm.GetInstance(config);

            //await EmptyDB("chat");
            //await EmptyDB("news");
            //await EmptyDB("formerPlayers");
            //await EmptyDB("matches");
            //await EmptyDB("clubs");

        }

        public async Task EmptyDB(string folder)
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/" + folder));
            _realm = Realm.GetInstance(config);
            //_realm.Write(() =>
            //{
            //    _realm.RemoveAll();
            //});
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
