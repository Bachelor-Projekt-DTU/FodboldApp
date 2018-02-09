using FodboldApp.View;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class LoginVM
    {
        public ICommand GooglePlusLoginCommand { get; set; }
        public ICommand FacebookLoginCommand { get; set; }

        async void GooglePlusOnTapped()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new GoogleLoginPage());
            Application.Current.MainPage.Navigation.PopAsync();
        }

        async void FacebookOnTapped()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new FBLoginPage());
        }

        public LoginVM()
        {
            GooglePlusLoginCommand = new Command(GooglePlusOnTapped);
            FacebookLoginCommand = new Command(FacebookOnTapped);
        }
    }
}
