using FodboldApp.Globals;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms.Platform.iOS;

namespace FodboldApp.iOS.CustomRenderers
{
    class GoogleLoginPageRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);


            GooglePlusSingleton.Instance.OAuthSettings.Completed += (sender, eventArgs) => {
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
            PresentViewController(GooglePlusSingleton.Instance.OAuthSettings.GetUI(), true, null);
        }
    }
}
