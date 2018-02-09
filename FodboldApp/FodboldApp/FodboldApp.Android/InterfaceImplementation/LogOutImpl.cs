using Android.Webkit;
using FodboldApp.Droid.InterfaceImplementation;
using FodboldApp.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(LogOutImpl))]
namespace FodboldApp.Droid.InterfaceImplementation
{
    class LogOutImpl : ILogOut
    {
        public void LogOutFB()
        {
            CookieManager.Instance.RemoveAllCookie();
        }

        public void LogOutGoogle()
        {
            CookieManager.Instance.RemoveAllCookie();
        }
    }
}