using FodboldApp.ViewModel;
using System;
using Xamarin.Auth;
using Xamarin.Forms;

namespace FodboldApp.Globals
{
    // Based on https://github.com/jsauve/OAuthTwoDemo.XForms/blob/master/OAuthTwoDemo.XForms/App.cs
    public class FacebookSingleton
    {
        static volatile FacebookSingleton _Instance;
        static object _SyncRoot = new Object();
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
                            _Instance = new FacebookSingleton();
                            _Instance.OAuthSettings =
                                new OAuth2Authenticator(
                                    clientId: "162558454388984",
                                    scope: "public_profile",                                   
                                    authorizeUrl: new Uri("https://facebook.com/v2.12/dialog/oauth/"), 
                                    redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));
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

        public Action SuccessfulLoginAction
        {
            get
            {
                Application.Current.Properties["Token"] = Instance.Token;
                ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
                Application.Current.Properties["IsUserLoggedIn"] = true;
                Application.Current.Properties["LoginType"] = "Facebook";
                ViewModelLocator.FacebookService.GetNameAsync(CurrentUser.user.AccessToken);
                ViewModelLocator.FacebookService.GetPictureAsync(CurrentUser.user.AccessToken);
                Console.WriteLine("Det virker");
                ViewModelLocator.HeaderVM.TypeOfLogin = HeaderVM.LoginType.Facebook;
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
