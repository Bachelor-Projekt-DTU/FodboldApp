using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FodboldApp
{
    public partial class Header : ContentPage
    {
        void Nyheder_Tapped(object sender, System.EventArgs e)
        {
            var page = new MainPage();
            PlaceHolder.Content = page.Content;
        }

        void Aaretsspiller_Tapped(object sender, System.EventArgs e)
        {
            var page = new MainPage();
            PlaceHolder.Content = page.Content;
        }

        void Turnering_Tapped(object sender, System.EventArgs e)
        {
            var page = new MainPage();
            PlaceHolder.Content = page.Content;
        }

        void Statistik_Tapped(object sender, System.EventArgs e)
        {
            var page = new MainPage();
            PlaceHolder.Content = page.Content;
        }

        void Burgermenu_Tapped(object sender, System.EventArgs e)
        {
            var page = new MainPage();
            PlaceHolder.Content = page.Content;
        }

        public Header()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}