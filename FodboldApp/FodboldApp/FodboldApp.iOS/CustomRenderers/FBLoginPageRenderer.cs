using FodboldApp.Globals;
using System;
using Xamarin.Auth;
using Xamarin.Forms.Platform.iOS;

namespace FodboldApp.iOS.CustomRenderers
{
    class FBLoginPageRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

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

            PresentViewController(FacebookSingleton.Instance.OAuthSettings.GetUI(), true, null);
        }
    }
}

