using FodboldApp.Model;
using FodboldApp.ViewModel;
using Realms;
using Realms.Sync;
using System;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;

namespace FodboldApp.Globals
{
    class GooglePlusSingleton
    {
        // Based on https://github.com/jsauve/OAuthTwoDemo.XForms/blob/master/OAuthTwoDemo.XForms/App.cs

        static volatile GooglePlusSingleton _Instance;
        static object _SyncRoot = new Object();
        //makes sure to have a working authenticator
        public static GooglePlusSingleton Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new GooglePlusSingleton();

                            string clientId = null;
                            string redirectUri = null;
                            switch (Device.RuntimePlatform)
                            {
                                case Device.iOS:
                                    clientId = GoogleConfigurations.iOSClientId;
                                    redirectUri = GoogleConfigurations.iOSRedirectUrl;
                                    break;

                                case Device.Android:
                                    clientId = GoogleConfigurations.AndroidClientId;
                                    redirectUri = GoogleConfigurations.AndroidRedirectUrl;
                                    break;
                            }

                            _Instance.OAuthSettings =
                                new OAuth2Authenticator(clientId, null, GoogleConfigurations.Scope, 
                                new Uri(GoogleConfigurations.AuthorizeUrl), 
                                new Uri(redirectUri), new Uri(GoogleConfigurations.AccessTokenUrl), null, true);
                        }
                    }
                }
                return _Instance;
            }
        }

        public OAuth2Authenticator OAuthSettings { get; private set; }

        //token is used to get user info from google
        string _Token;
        public string Token
        {
            get { return _Token; }

        }

        public void SaveToken(string token)
        {
            _Token = token;
        }

        public void ResetAuthentication()
        {
            _Instance = null;
        }

        public void RemoveToken()
        {
            _Token = null;
        }

        //uses token to get user info
        public async void GetUserInfoAsync()
        {
            try
            {
                CurrentUser.user.Name = await ViewModelLocator.GoogleService.GetNameAsync(CurrentUser.user.AccessToken);
                CurrentUser.user.Picture = await ViewModelLocator.GoogleService.GetPictureAsync(CurrentUser.user.AccessToken);
                CurrentUser.user.Id = await ViewModelLocator.GoogleService.GetIdAsync(CurrentUser.user.AccessToken);

                Realm _realm;
                var user = await User.LoginAsync(Credentials.UsernamePassword("StandardUser", "12345", false), new Uri($"http://13.59.205.12:9080"));
                var config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/admins"));
                _realm = Realm.GetInstance(config);

                //repeatedly checks the server for admin status to avoid bug
                for (int i = 0; i < 5; i++)
                {
                    if (_realm.Find<AdminModel>(CurrentUser.user.Id) != null)
                    {
                        CurrentUser.IsAdmin = true;
                        break;
                    }
                    await Task.Delay(500);
                }
                ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
            }
            catch (Exception)
            {
                Application.Current.Properties.Remove("IsUserLoggedIn");
                ViewModelLocator.HeaderVM.HasAutoLoginFailed = true;
            }
        }

        public Action SuccessfulLoginAction
        {
            get
            {
                Application.Current.Properties["Token"] = Instance.Token;
                CurrentUser.user.AccessToken = Instance.Token;
                ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
                Application.Current.Properties["IsUserLoggedIn"] = true;
                Application.Current.Properties["LoginType"] = "Google";
                ViewModelLocator.HeaderVM.TypeOfLogin = HeaderVM.LoginType.Google;
                GetUserInfoAsync();
                return new Action(() => Application.Current.MainPage.Navigation.PopToRootAsync());
            }
        }

        public Action FailedLoginAction
        {
            get
            {
                return new Action(() => Application.Current.MainPage.Navigation.PopAsync());
            }
        }
    }
}
