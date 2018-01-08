using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FodboldApp.Data;
using System.Net;
using System.IO;
using System;
using FodboldApp.Pages;

namespace FodboldApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Players : ContentPage
    {
        public Players()
        {
            InitializeComponent();
        }

        async void Players_Tapped(object sender, EventArgs e)
        {
            await ((App)App.Current).MainPage.Navigation.PushAsync(new PlayerDescription());

            Console.WriteLine("Players_Tapped");
        }
    }
}