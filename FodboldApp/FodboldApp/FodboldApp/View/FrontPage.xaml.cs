using FodboldApp.ViewModel;
using Xamarin.Forms;

namespace FodboldApp
{
    public partial class FrontPage : ContentPage
    {
        public FrontPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new FrontpageVM();

            // Listviewet skal reduceres for at fjerne tomrum: HeightRequest = (#items * itemHeight) +(Standardhøjde + #items)
            clubList.HeightRequest = (5 * clubList.RowHeight) + (10 * 22.5);
        }
    }
}
