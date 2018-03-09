using FodboldApp.ViewModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FodboldApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            HeaderVM.SetContent(pageContent);
            ViewModelLocator.HeaderVM.CreateStack();
            ViewModelLocator.HeaderVM.NewsTap();
            Task.Run(()=>NoInternetVM.IsConnectedOnMainPage(null));

            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override bool OnBackButtonPressed()
        {
            ViewModelLocator.HeaderVM.BackButtonPressed();
            return true;
        }
    }
}