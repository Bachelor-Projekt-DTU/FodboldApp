using FodboldApp.Globals;
using FodboldApp.iOS.CustomRenderers;
using FodboldApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FBLoginPage), typeof(FBLoginPageRenderer))]
namespace FodboldApp.iOS.CustomRenderers
{
    class FBLoginPageRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            var viewController = FacebookSingleton.Instance.OAuthSettings.GetUI();

            FacebookSingleton.Instance.OAuthSettings.Completed += (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    Console.WriteLine("Virker");
                    FacebookSingleton.Instance.SaveToken(eventArgs.Account.Properties["access_token"]);
                    FacebookSingleton.Instance.SuccessfulLoginAction.Invoke();
                    viewController.DismissViewController(true, null);
                }
                else
                {
                    FacebookSingleton.Instance.FailedLoginAction.Invoke();
                    FacebookSingleton.Instance.ResetAuthentication();
                }
            };
            PresentViewController(viewController, true, null);

        }
    }
}

