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
    // Based on https://github.com/jsauve/OAuthTwoDemo.XForms/blob/master/OAuthTwoDemo.XForms/App.cs
    public class FacebookSingleton
    {
        static volatile FacebookSingleton _Instance;
        static object _SyncRoot = new Object();
        //makes sure to have a working authenticator
        public static FacebookSingleton Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new FacebookSingleton
                            {
                                OAuthSettings =
                                new OAuth2Authenticator(
                                    clientId: "162558454388984",
                                    scope: "public_profile",
                                    authorizeUrl: new Uri("https://facebook.com/v2.12/dialog/oauth/"),
                                    redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"))
                            };
                        }
                    }
                }

                return _Instance;
            }
        }

        public OAuth2Authenticator OAuthSettings { get; private set; }

        public void ResetAuthentication()
        {
            _Instance = null;
        }

        //token is used to get user info from facebook
        string _Token;
        public string Token
        {
            get { return _Token; }

        }

        public void SaveToken(string token)
        {
            _Token = token;
        }

        public void RemoveToken()
        {
            _Token = null;
        }

        //uses token to get user info
        public async void GetUserInfoAsync()
        {
            CurrentUser.user.Name = await ViewModelLocator.FacebookService.GetNameAsync(CurrentUser.user.AccessToken);
            CurrentUser.user.Picture = (await ViewModelLocator.FacebookService.GetPictureAsync(CurrentUser.user.AccessToken)).Data.Url;
            CurrentUser.user.Id = await ViewModelLocator.FacebookService.GetIdAsync(CurrentUser.user.AccessToken);
            Console.WriteLine("Userinfo: " + CurrentUser.user.Name + " " + CurrentUser.user.Picture + " " + CurrentUser.user.Id);

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
        }

        public Action SuccessfulLoginAction
        {
            get
            {
                Application.Current.Properties["Token"] = Instance.Token;
                CurrentUser.user.AccessToken = Instance.Token;
                ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
                Application.Current.Properties["IsUserLoggedIn"] = true;
                Application.Current.Properties["LoginType"] = "Facebook";
                ViewModelLocator.HeaderVM.TypeOfLogin = HeaderVM.LoginType.Facebook;
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
