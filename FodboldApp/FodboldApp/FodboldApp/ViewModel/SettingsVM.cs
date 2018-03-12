using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    public class SettingsVM
    {
        public ICommand ChangeClubCommand { get; private set; }
        void ChangeClubCommandOnTapped()
        {
            Application.Current.MainPage.Navigation.InsertPageBefore(new FrontPage(), ((NavigationPage)Application.Current.MainPage).CurrentPage);
            Application.Current.MainPage.Navigation.PopAsync();
        }
        public SettingsVM()
        {
            ChangeClubCommand = new Command(ChangeClubCommandOnTapped);
        }
    }
}
