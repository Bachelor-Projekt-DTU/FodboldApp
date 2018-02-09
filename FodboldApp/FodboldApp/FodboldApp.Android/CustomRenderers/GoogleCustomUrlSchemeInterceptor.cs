using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Content.PM;
using FodboldApp.Globals;

namespace FodboldApp.Droid.CustomRenderers
{
    [Activity(Label = "CustomUrlSchemeInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTask)]
    [IntentFilter(new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataSchemes = new[] { "com.googleusercontent.apps.274704195206-lhp82rg3vo8fivj5do0amtrurjtjdv2a" },
    DataPaths = new[] { "/oauth2redirect" })]

    public class GoogleCustomUrlSchemeInterceptor : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Convert Android.Net.Url to Uri
            var uri = new Uri(Intent.Data.ToString());

            // Load redirectUrl page
            GooglePlusSingleton.Instance.OAuthSettings.OnPageLoading(uri);

            Finish();
        }
    }
}