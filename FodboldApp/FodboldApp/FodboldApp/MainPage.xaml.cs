using Plugin.CrossPlatformTintedImage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FodboldApp
{
    public partial class MainPage : ContentPage
    {
        void ResetIconTint()
        {
            tintedImage_News.TintColor = Color.FromRgb(84,84,84);
            tintedImage_Players.TintColor = Color.FromRgb(84, 84, 84);
            tintedImage_Matches.TintColor = Color.FromRgb(84, 84, 84);
            tintedImage_Tournament.TintColor = Color.FromRgb(84, 84, 84);
            tintedImage_History.TintColor = Color.FromRgb(84, 84, 84);
        }

        void News_Tapped(object sender, EventArgs e)
        {
            ResetIconTint();
            var page = new News();
            PlaceHolder.Content = page.Content;
            tintedImage_News.TintColor = Color.FromRgb(49, 91, 170);
        }

        void Players_Tapped(object sender, EventArgs e)
        {
            ResetIconTint();
            var page = new Players();
            PlaceHolder.Content = page.Content;
            tintedImage_Players.TintColor = Color.FromRgb(49, 91, 170);
        }

        void Matches_Tapped(object sender, EventArgs e)
        {
            ResetIconTint();
            var page = new Matches();
            PlaceHolder.Content = page.Content;
            tintedImage_Matches.TintColor = Color.FromRgb(49, 91, 170);
        }

        void Tournament_Tapped(object sender, EventArgs e)
        {
            ResetIconTint();
            var page = new Tournament();
            PlaceHolder.Content = page.Content;
            tintedImage_Tournament.TintColor = Color.FromRgb(49, 91, 170);
        }

        void History_Tapped(object sender, EventArgs e)
        {
            ResetIconTint();
            var page = new History();
            PlaceHolder.Content = page.Content;
            tintedImage_History.TintColor = Color.FromRgb(49, 91, 170);
        }

        public MainPage()
        {
            InitializeComponent();
          
            ResetIconTint();

            News_Tapped(news, new EventArgs ());

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}