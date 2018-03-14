using FodboldApp.Stack;
using FodboldApp.View;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    public class SettingsVM
    {
        public ICommand ChatTestCommand { get; private set; }
        public ICommand ChangeClubCommand { get; private set; }
        void ChangeClubCommandOnTapped()
        {
            Application.Current.MainPage.Navigation.InsertPageBefore(new FrontPage(), ((NavigationPage)Application.Current.MainPage).CurrentPage);
            Application.Current.MainPage.Navigation.PopAsync();
        }

        void ChatTest()
        {
            CustomStack.Instance.HistoryContent.PushAsync(new Chat());
            ViewModelLocator.HeaderVM.UpdateContent();
        }

        public SettingsVM()
        {
            ChangeClubCommand = new Command(ChangeClubCommandOnTapped);
            ChatTestCommand = new Command(ChatTest);
        }
    }
}
