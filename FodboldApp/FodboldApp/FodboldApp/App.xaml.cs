using Com.OneSignal;
using DLToolkit.Forms.Controls;
using FodboldApp.Interfaces;
using FodboldApp.View;
using FodboldApp.ViewModel;
using Realms;
using Realms.Sync;
using System;
using System.Threading.Tasks;
using Xamarians.GoogleLogin.Interface;
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
            MainPage = new NavigationPage(new FrontPage());

            OneSignal.Current.StartInit("84ec0128-74a1-40f9-89b1-35e35da35acd")
                  .EndInit();

            InitializeComponent();

            vm = ViewModelLocator.HeaderVM;

            BindingContext = vm;

            FlowListView.Init();

            if (Application.Current.Properties.ContainsKey("IsUserLoggedIn"))
            {
                if((string)Current.Properties["LoginType"] == "Google")
                GooglePlusOnTappedAsync();
            
            }

            MainPage = new NavigationPage(new FrontPage());

            NavigationPage.SetHasNavigationBar(this, false);
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


        async void GooglePlusOnTappedAsync()
        {
            var result = await DependencyService.Get<IGoogleLogin>().SignIn();
            if (result.IsSuccess)
            {
                ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
                ViewModelLocator.HeaderVM.TypeOfLogin = HeaderVM.LoginType.Google;
                var username = result.Name;
                Console.WriteLine("Brugernavn " + username);
                var userimage = result.Image;
                Console.WriteLine(userimage);
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
        public async void LoginOut(object sender, EventArgs e)
        {
            ViewModelLocator.HeaderVM.IsUserLoggedIn = false;
            if (Application.Current.Properties.ContainsKey("IsUserLoggedIn"))
            {
                Console.WriteLine("Hold ud");
                Application.Current.Properties.Remove("IsUserLoggedIn");
            }

            if (ViewModelLocator.HeaderVM.TypeOfLogin == HeaderVM.LoginType.Google)
            {
                await DependencyService.Get<ILogOut>().LogOutGoogleAsync();
            }
            else if (ViewModelLocator.HeaderVM.TypeOfLogin == HeaderVM.LoginType.Facebook)
            {           
                DependencyService.Get<ILogOut>().LogOutFB();   
            }
        }
    }
}
