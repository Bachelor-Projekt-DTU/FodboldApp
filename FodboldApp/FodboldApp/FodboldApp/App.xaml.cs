using Com.OneSignal;
using DLToolkit.Forms.Controls;
using FodboldApp.Globals;
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
    public partial class App : Xamarin.Forms.Application
    {
        HeaderVM vm;
        Realm _realm;
        public static SearchBar Searchbar;

        public App()
        {
            SetupRealmAsync();

            OneSignal.Current.StartInit("84ec0128-74a1-40f9-89b1-35e35da35acd")
                  .EndInit();

            InitializeComponent();

            var temp = this.FindByName<ControlTemplate>("Template");
            //temp.
            Console.WriteLine("ok here we go fam" + Searchbar);

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

            //ViewModelLocator.NoInternetVM.IsConnectedOnFrontPage(null);
            MainPage = new NavigationPage(new FrontPage());

            NavigationPage.SetHasNavigationBar(this, false);
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

        public async Task SetupRealmAsync()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data"));
            _realm = Realm.GetInstance(config);
        }

        public async Task EmptyDB(string folder)
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/" + folder));
            _realm = Realm.GetInstance(config);
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
