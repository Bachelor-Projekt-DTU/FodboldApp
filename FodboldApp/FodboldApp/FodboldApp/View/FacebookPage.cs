using FodboldApp.Model;
using FodboldApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.View
{
    class FacebookPage : ContentPage
    {
        private string ClientId = "162558454388984";

        public FacebookPage()
        {
            BindingContext = ViewModelLocator.FacebookLoginVM;

            var apiRequest =
                "https://www.facebook.com/v2.11/dialog/oauth?client_id="
                + ClientId
                + "&display=popup&response_type=token&redirect_uri=http://www.facebook.com/connect/login_success.html";

            var webView = new WebView
            {
                Source = apiRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;

            Content = webView;
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {

            var accessToken = ExtractAccessTokenFromUrl(e.Url);

            if (accessToken != "")
            {
                var vm = BindingContext as FacebookLoginVM;
                await vm.SetFacebookUserProfileAsync(accessToken);
                ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
                ViewModelLocator.HeaderVM.TypeOfLogin = HeaderVM.LoginType.Facebook;
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
        }

        private string ExtractAccessTokenFromUrl(string url)
        {
            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                var accessToken = at.Remove(at.IndexOf("&expires_in="));
                return accessToken;
            }

            return string.Empty;
        }
    }
}
