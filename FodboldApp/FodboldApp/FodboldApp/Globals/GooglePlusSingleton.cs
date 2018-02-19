using FodboldApp.ViewModel;
using System;
using Xamarin.Auth;
using Xamarin.Forms;

namespace FodboldApp.Globals
{
    class GooglePlusSingleton
    {
        // Based on https://github.com/jsauve/OAuthTwoDemo.XForms/blob/master/OAuthTwoDemo.XForms/App.cs

        static volatile GooglePlusSingleton _Instance;
        static object _SyncRoot = new Object();
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

        public Action SuccessfulLoginAction
        {
            get
            {
                Xamarin.Forms.Application.Current.Properties["Token"] = Instance.Token;
                ViewModel.ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
                Xamarin.Forms.Application.Current.Properties["IsUserLoggedIn"] = true;
                Xamarin.Forms.Application.Current.Properties["LoginType"] = "Google";
                ViewModel.ViewModelLocator.GoogleService.GetNameAsync(CurrentUser.user.AccessToken);
                ViewModel.ViewModelLocator.GoogleService.GetPictureAsync(CurrentUser.user.AccessToken);
                Console.WriteLine("Det virker");
                ViewModel.ViewModelLocator.HeaderVM.TypeOfLogin = HeaderVM.LoginType.Google;
                return new Action(() => Xamarin.Forms.Application.Current.MainPage.Navigation.PopToRootAsync());
            }
        }

        public Action FailedLoginAction
        {
            get
            {
                return new Action(() => Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync());
            }
        }
    }
}
