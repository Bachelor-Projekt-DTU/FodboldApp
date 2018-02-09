
using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using Plugin.CrossPlatformTintedImage.Android;
using ImageCircle.Forms.Plugin.Droid;
using FFImageLoading.Forms.Droid;
using CarouselView.FormsPlugin.Android;
using Realms;
using RoundedBoxView.Forms.Plugin.Droid;
using System;
using Android.Gms.Common;
using Android.Content;
using Com.OneSignal;

namespace FodboldApp.Droid
{
    [Activity(Label = "FodboldApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Realm.GetInstance();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircleRenderer.Init();

            Window window = this.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            window.SetStatusBarColor(Android.Graphics.Color.Rgb(251, 67, 60));
            LoadApplication(new App());
            TintedImageRenderer.Init();
            CarouselViewRenderer.Init();
            RoundedBoxViewRenderer.Init();
            CachedImageRenderer.Init(enableFastRenderer: true);

            OneSignal.Current.StartInit("84ec0128-74a1-40f9-89b1-35e35da35acd")
                  .EndInit();

            if (IsPlayServicesAvailable())
            {
                var intent = new Intent(this, typeof(RegistrationIntentService));
                StartService(intent);
            }
        }

        public bool IsPlayServicesAvailable()
        {
            Console.WriteLine("EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEY");
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    Console.WriteLine("type 1 cancer");
                //msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    //msgText.Text = "Sorry, this device is not supported";
                    Finish();
                }
                return false;
            }
            else
            {
                //msgText.Text = "Google Play Services is available.";
                return true;
            }
        }
    }
}

