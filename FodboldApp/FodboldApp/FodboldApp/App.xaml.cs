using Com.OneSignal;
using DLToolkit.Forms.Controls;
using FodboldApp.Interfaces;
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
            ViewModelLocator.HeaderVM.IsUserLoggedIn = false;

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
