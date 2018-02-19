using FodboldApp.View;
using Plugin.Connectivity;
using Realms;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    public class NoInternetVM
    {
        Realm _realm;

        public async Task<bool> IsConnectedOnMainPage(SyncConfiguration syncConfiguration)
        {
            while (CrossConnectivity.Current.IsConnected == false)
            {
                ViewModelLocator.HeaderVM.NoInternetHandler();
                Thread.Sleep(1000);
                await IsConnectedOnMainPage(syncConfiguration);
            }
            return true;
        }

        public void IsConnectedOnFrontPage(SyncConfiguration syncConfiguration)
        {
            if (CrossConnectivity.Current.IsConnected == false)
            {
                CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
                {
                    Application.Current.MainPage = new NavigationPage(new FrontPage());
                };
            }
            Application.Current.MainPage = new NoInternetPage();
//            return await SetupRealm();
        }

        public async Task<Realm> SetupRealm()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/clubs"));
            _realm = Realm.GetInstance(config);

            return _realm;
        }

    }
}
