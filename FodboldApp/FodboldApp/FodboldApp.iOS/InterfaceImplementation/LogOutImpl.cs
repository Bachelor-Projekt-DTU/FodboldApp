using FodboldApp.Droid.InterfaceImplementation;
using FodboldApp.Interfaces;
using FodboldApp.ViewModel;
using Foundation;
using Google.SignIn;

[assembly: Xamarin.Forms.Dependency(typeof(LogOutImpl))]
namespace FodboldApp.Droid.InterfaceImplementation
{
    class LogOutImpl : ILogOut
    {
        public void LogOutFB()
        {
            ViewModelLocator.FacebookLoginVM.FacebookProfile = null;
            NSHttpCookieStorage CookieStorage = NSHttpCookieStorage.SharedStorage;

            foreach (var cookie in CookieStorage.Cookies)
                CookieStorage.DeleteCookie(cookie);
        }

        public async System.Threading.Tasks.Task LogOutGoogleAsync()
        {
            SignIn.SharedInstance.SignOutUser();
        }
    }
}