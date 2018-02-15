using FodboldApp.Droid.InterfaceImplementation;
using FodboldApp.Interfaces;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(LogOutImpl))]
namespace FodboldApp.Droid.InterfaceImplementation
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
            SignIn.SharedInstance.SignOutUser();
        }
    }
}