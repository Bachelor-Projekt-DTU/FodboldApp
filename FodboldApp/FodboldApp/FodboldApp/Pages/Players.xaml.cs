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

            //Add tap handler to grid_Element0:
            TapGestureRecognizer tapEvent = new TapGestureRecognizer();

            //Connect event handler (Players_Tapped) to TapGestureRecognizer:
            tapEvent.Tapped += Players_Tapped;

            //Add TapGestureRecognizer to grid_Element0:
            grid_Element0.GestureRecognizers.Add(tapEvent);


            async
            void Players_Tapped(object sender, EventArgs e)
            {
            await ((App) App.Current).MainPage.Navigation.PushAsync(new Player_Description ());
   
                Console.WriteLine("Players_Tapped");
            }
        }
    }
}