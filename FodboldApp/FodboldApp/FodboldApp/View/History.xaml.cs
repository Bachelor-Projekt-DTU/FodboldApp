using FodboldApp.Stack;
using FodboldApp.View;
using FodboldApp.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FodboldApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History : ContentPage
	{
        public History()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new HistoryVM();
        }
    }
}
