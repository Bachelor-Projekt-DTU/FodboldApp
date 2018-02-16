using FodboldApp.iOS.InterfaceImplementation;
using FodboldApp.Interfaces;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(LogOutImpl))]
namespace FodboldApp.iOS.InterfaceImplementation
{
    class LogOutImpl : ILogOut
    {
        public void LogOutFB()
        {
            NSHttpCookieStorage CookieStorage = NSHttpCookieStorage.SharedStorage;

            foreach (var cookie in CookieStorage.Cookies)
                CookieStorage.DeleteCookie(cookie);
        }

        public void LogOutGoogle()
        {
            NSHttpCookieStorage CookieStorage = NSHttpCookieStorage.SharedStorage;

            foreach (var cookie in CookieStorage.Cookies)
                CookieStorage.DeleteCookie(cookie);
        }
    }
}