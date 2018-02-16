using FodboldApp.Globals;
using FodboldApp.iOS.CustomRenderers;
using FodboldApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GoogleLoginPage), typeof(GoogleLoginPageRenderer))]
namespace FodboldApp.iOS.CustomRenderers
{
    class GoogleLoginPageRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            var viewController = GooglePlusSingleton.Instance.OAuthSettings.GetUI();

            GooglePlusSingleton.Instance.OAuthSettings.Completed += (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    Console.WriteLine("Virker");
                    GooglePlusSingleton.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);
                    GooglePlusSingleton.Instance.SuccessfulLoginAction.Invoke();
                    viewController.DismissViewController(animated, null);
                }
                else
                {
                    Console.WriteLine("Virker ikke");
                    GooglePlusSingleton.Instance.FailedLoginAction.Invoke();
                }
            };

            PresentViewController(viewController, true, null);
        }
    }
}
