using System;
using System.Windows.Input;
using Xamarians.GoogleLogin.Interface;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class LoginVM
    {
        public ICommand GooglePlusLoginCommand { get; set; }

        async void GooglePlusOnTappedAsync()
        {
            var result = await DependencyService.Get<IGoogleLogin>().SignIn();
            if (result.IsSuccess)
            {
                ViewModelLocator.HeaderVM.IsUserLoggedIn = true;
                var username = result.Name;
                Console.WriteLine("Brugernavn "+ username);
                var userimage = result.Image;
                Console.WriteLine(userimage);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        public LoginVM()
        {
            GooglePlusLoginCommand = new Command(GooglePlusOnTappedAsync);
        }
    }
}
