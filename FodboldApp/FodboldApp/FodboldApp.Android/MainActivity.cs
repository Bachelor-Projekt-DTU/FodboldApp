using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.CrossPlatformTintedImage.Android;
using ImageCircle.Forms.Plugin.Droid;
using FFImageLoading.Forms.Droid;
using CarouselView.FormsPlugin.Android;
using Realms;
using RoundedBoxView.Forms.Plugin.Droid;

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
        }
    }
}

