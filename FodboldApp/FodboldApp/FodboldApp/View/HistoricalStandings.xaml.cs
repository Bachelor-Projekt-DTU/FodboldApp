using FodboldApp.Model;
using FodboldApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoricalStandings : ContentPage
    {
        protected override bool OnBackButtonPressed()
        {
            HeaderVM.BackButtonPressed();
            return true;
        }

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