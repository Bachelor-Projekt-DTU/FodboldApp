using System;
using Android.App;
using Android.Content;
using FodboldApp.Droid.CustomRenderers;
using FodboldApp.Globals;
using FodboldApp.View;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FBLoginPage), typeof(FBLoginPageRendererPageRenderer))]
namespace FodboldApp.Droid.CustomRenderers
{
    // Based on http://www.joesauve.com/using-xamarin-auth-with-xamarin-forms/

    public class FBLoginPageRendererPageRenderer : PageRenderer
    {
        public FBLoginPageRendererPageRenderer(Context context) : base(context)
        {
            
        }   

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = Context as Activity;
            activity.StartActivity(FacebookSingleton.Instance.OAuthSettings.GetUI(activity));

            FacebookSingleton.Instance.OAuthSettings.Completed += (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    Console.WriteLine("Virker");
                    FacebookSingleton.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);
                    FacebookSingleton.Instance.SuccessfulLoginAction.Invoke();
                }
                else
                {
                    FacebookSingleton.Instance.FailedLoginAction.Invoke();
                    FacebookSingleton.Instance.ResetAuthentication();
                }
            };
        }
    }
}