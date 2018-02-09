using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Support.CustomTabs;
using FodboldApp.Droid.CustomRenderers;
using FodboldApp.Globals;
using FodboldApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GoogleLoginPage), typeof(GoogleLoginPageRenderer))]

namespace FodboldApp.Droid.CustomRenderers
{
    class GoogleLoginPageRenderer : PageRenderer
    {
        public GoogleLoginPageRenderer(Context context) : base(context)
        {
            var activity = Context as Activity;
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            
            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = Context as Activity;

            activity.StartActivity(GooglePlusSingleton.Instance.OAuthSettings.GetUI(activity));

            GooglePlusSingleton.Instance.OAuthSettings.Completed += (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    Console.WriteLine("Virker");
                    GooglePlusSingleton.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);
                    GooglePlusSingleton.Instance.SuccessfulLoginAction.Invoke();
                }
                else
                {
                    Console.WriteLine("Virker ikke");
                    GooglePlusSingleton.Instance.FailedLoginAction.Invoke();
                }
            };
        }
    }
}