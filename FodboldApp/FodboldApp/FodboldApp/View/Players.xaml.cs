using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FodboldApp.Model;
using System.Net;
using System.IO;
using System;
using FodboldApp.View;
using FodboldApp.ViewModel;

namespace FodboldApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Players : ContentPage
    {
        public Players()
        {
            InitializeComponent();
            BindingContext = new PlayerVM();
        }
        async void Players_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayerDescription());

            Console.WriteLine("Players_Tapped");
        }
    }
}