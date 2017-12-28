using Plugin.CrossPlatformTintedImage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FodboldApp
{
    public partial class Header : ContentPage
    {
        void ResetIconTint()
        {
            tintedImage_Nyheder.TintColor = Color.FromRgb(84,84,84);
            tintedImage_Aaretsspiller.TintColor = Color.FromRgb(84, 84, 84);
            tintedImage_Turnering.TintColor = Color.FromRgb(84, 84, 84);
            tintedImage_Statistik.TintColor = Color.FromRgb(84, 84, 84);
            tintedImage_Burgermenu.TintColor = Color.FromRgb(84, 84, 84);
        }

        void Nyheder_Tapped(object sender, EventArgs e)
        {
            ResetIconTint();
            var page = new MainPage();
            PlaceHolder.Content = page.Content;
            tintedImage_Nyheder.TintColor = Color.FromRgb(49, 91, 170);
        }

        void Aaretsspiller_Tapped(object sender, EventArgs e)
        {
            ResetIconTint();
            var page = new MainPage();
            PlaceHolder.Content = page.Content;
            tintedImage_Aaretsspiller.TintColor = Color.FromRgb(49, 91, 170);
        }

        void Turnering_Tapped(object sender, EventArgs e)
        {
            ResetIconTint();
            var page = new MainPage();
            PlaceHolder.Content = page.Content;
            tintedImage_Turnering.TintColor = Color.FromRgb(49, 91, 170);
        }

        void Statistik_Tapped(object sender, EventArgs e)
        {
            ResetIconTint();
            var page = new MainPage();
            PlaceHolder.Content = page.Content;
            tintedImage_Statistik.TintColor = Color.FromRgb(49, 91, 170);
        }

        void Burgermenu_Tapped(object sender, EventArgs e)
        {
            ResetIconTint();
            var page = new MainPage();
            PlaceHolder.Content = page.Content;
            tintedImage_Burgermenu.TintColor = Color.FromRgb(49, 91, 170);
        }

        public Header()
        {
            InitializeComponent();
            ResetIconTint();
        }
    }
}