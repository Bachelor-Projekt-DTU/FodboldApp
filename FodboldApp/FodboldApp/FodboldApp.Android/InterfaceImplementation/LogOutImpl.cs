using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using FodboldApp.Droid.InterfaceImplementation;
using FodboldApp.Interfaces;
using FodboldApp.ViewModel;
using Xamarians.GoogleLogin.Interface;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(LogOutImpl))]
namespace FodboldApp.Droid.InterfaceImplementation
{
    class LogOutImpl : ILogOut
    {
        public void LogOutFB()
        {
            ViewModelLocator.FacebookLoginVM.FacebookProfile = null;
            CookieManager.Instance.RemoveAllCookie();
        }

        public async System.Threading.Tasks.Task LogOutGoogleAsync()
        {
            var result = await DependencyService.Get<IGoogleLogin>().SignOut();
            if (result.IsSuccess)
            {
                Console.WriteLine("Logget ud");
            }
        }
    }
}