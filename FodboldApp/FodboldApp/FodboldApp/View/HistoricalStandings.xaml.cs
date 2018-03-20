using FodboldApp.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoricalStandings : ContentPage
    {
        protected override bool OnBackButtonPressed()
        {
            ViewModelLocator.HeaderVM.BackButtonPressed();
            return true;
        }

        public HistoricalStandings()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new HistoricalStandingVM();
            standingsList.HeightRequest = (5 * standingsList.RowHeight) + (10 * 22.5);
        }       
    }
}