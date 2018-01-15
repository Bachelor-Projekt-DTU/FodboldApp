using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FodboldApp.Model;
using System.Net;
using System.IO;
using System;
using FodboldApp.Pages;
using FodboldApp.Stack;

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
            await CustomStack.Instance.PlayerContent.Navigation.PushAsync(new PlayerDescription());
            await Navigation.PushAsync(new PlayerDescription());

            Console.WriteLine("Players_Tapped");
        }
    }
}