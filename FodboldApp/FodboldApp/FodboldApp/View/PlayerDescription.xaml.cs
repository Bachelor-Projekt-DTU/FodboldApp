using FodboldApp.Model;
using FodboldApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerDescription : ContentPage
    {

        protected override bool OnBackButtonPressed()
        {
            ViewModelLocator.HeaderVM.BackButtonPressed();
            return true;
        }

        public PlayerDescription(PlayerModel player)
        {
            InitializeComponent();
            ViewModelLocator.PlayerDescriptionVM.Player = player;
        }
    }
}