using FodboldApp.Stack;
using FodboldApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Players : ContentPage
    {
        public Players()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void Players_Tapped(object sender, EventArgs e)
        {
            await CustomStack.Instance.PlayerContent.Navigation.PushAsync(new PlayerDescription());
            await Navigation.PushAsync(new PlayerDescription());

            Console.WriteLine("Players_Tapped");
        }
    }
}