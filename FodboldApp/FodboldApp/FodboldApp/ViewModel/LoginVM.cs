using FodboldApp.View;
using System;
using System.Windows.Input;
using Xamarians.GoogleLogin.Interface;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class LoginVM
    {
        public ICommand GooglePlusLoginCommand { get; set; }
        public ICommand FacebookLoginCommand { get; set; }

        async void GooglePlusOnTappedAsync()
        {
            var result = await DependencyService.Get<IGoogleLogin>().SignIn();
            if (result.IsSuccess)
            {
                ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
                ViewModelLocator.HeaderVM.TypeOfLogin = HeaderVM.LoginType.Google;
                var username = result.Name;
                Console.WriteLine("Brugernavn " + username);
                var userimage = result.Image;
                Console.WriteLine(userimage);
                Application.Current.Properties["IsUserLoggedIn"] = true;
                Application.Current.Properties["LoginType"] = "Google";
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        async void FacebookOnTapped()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new FacebookPage());
        }

        public LoginVM()
        {
            GooglePlusLoginCommand = new Command(GooglePlusOnTappedAsync);
            FacebookLoginCommand = new Command(FacebookOnTapped);
        }
    }
}
