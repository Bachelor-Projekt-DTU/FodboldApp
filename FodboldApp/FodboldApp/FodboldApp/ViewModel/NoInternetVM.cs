using FodboldApp.View;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Realms;
using Realms.Sync;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    public class NoInternetVM
    {
        //sets content to an error page if the phone does not have internet access
        public static async Task<Realm> IsConnectedOnMainPage(string path)
        {
            if (CrossConnectivity.Current.IsConnected == false)
            {
                CrossConnectivity.Current.ConnectivityChanged += UpdateRealm;
                ViewModelLocator.HeaderVM.NoInternetHandler();
            }
            try
            {
                var user = await User.LoginAsync(Credentials.UsernamePassword("StandardUser", "12345", false), new Uri($"http://13.59.205.12:9080"));
                SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/" + path));
                return Realm.GetInstance(config);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Realm.GetInstance();
            }
        }
        
        //resets all navigationpages on reconnection to the internet
        public static void UpdateRealm(object sender, ConnectivityChangedEventArgs arg)
        {
            ViewModelLocator.HeaderVM.ResetStack();
            CrossConnectivity.Current.ConnectivityChanged -= UpdateRealm;
        }

        //sets content to an error page if the phone does not have internet access
        public void IsConnectedOnFrontPage(string path)
        {
            if (CrossConnectivity.Current.IsConnected == false)
            {

                CrossConnectivity.Current.ConnectivityChanged += ChangeToNoInternetPage;
                Application.Current.MainPage = new NoInternetPage();
            }
            else Application.Current.MainPage = new NavigationPage(new FrontPage());
        }

        public async void ChangeToNoInternetPage(object sender, ConnectivityChangedEventArgs args)
        {
            Application.Current.MainPage = new NavigationPage(new FrontPage());
            CrossConnectivity.Current.ConnectivityChanged -= ChangeToNoInternetPage;
        }
    }
}
