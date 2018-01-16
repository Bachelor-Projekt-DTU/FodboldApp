using FodboldApp.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoricalStandings : ContentPage
    {

        public HistoricalStandings()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new HistoricalStandingVM();
            Console.WriteLine("Fejlen " + ((App)Application.Current).MainPage.BindingContext.ToString());
            // Reducing listview to remove empty space : HeightRequest = (#items * itemHeight) +(Standard height + #items)
            standingsList.HeightRequest = (5 * standingsList.RowHeight) + (10 * 22.5);
        }       
    }
}