using CarouselView.FormsPlugin.iOS;
using Com.OneSignal;
using FFImageLoading.Forms.Touch;
using FodboldApp.Globals;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using Plugin.CrossPlatformTintedImage.iOS;
using RoundedBoxView.Forms.Plugin.iOSUnified;
using System;
using UIKit;

namespace FodboldApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            ImageCircleRenderer.Init();

            var statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
            {
                statusBar.BackgroundColor = UIColor.FromRGB(251, 67, 60);
                statusBar.TintColor = UIColor.White;
            }
            LoadApplication(new App());
            TintedImageRenderer.Init();
            CachedImageRenderer.Init();
            RoundedBoxViewRenderer.Init();
            CarouselViewRenderer.Init();
            Xamarians.GoogleLogin.iOS.DS.GoogleLogin.Init();

            var googleServiceDictionary = NSDictionary.FromFile("GoogleService-Info.plist");
            SignIn.SharedInstance.ClientID = googleServiceDictionary["CLIENT_ID"].ToString();

            OneSignal.Current.StartInit("84ec0128-74a1-40f9-89b1-35e35da35acd")
                  .EndInit();

            return base.FinishedLaunching(app, options);
        }

        // For iOS 9 or newer
        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            var openUrlOptions = new UIApplicationOpenUrlOptions(options);
            var uri = new Uri(url.AbsoluteString);
            GooglePlusSingleton.Instance.OAuthSettings.OnPageLoading(uri);

            return SignIn.SharedInstance.HandleUrl(url, openUrlOptions.SourceApplication, openUrlOptions.Annotation);

        }

        // For iOS 8 and older
        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            var uri = new Uri(url.AbsoluteString);
            GooglePlusSingleton.Instance.OAuthSettings.OnPageLoading(uri);
            return SignIn.SharedInstance.HandleUrl(url, sourceApplication, annotation);
        }
    }
}
