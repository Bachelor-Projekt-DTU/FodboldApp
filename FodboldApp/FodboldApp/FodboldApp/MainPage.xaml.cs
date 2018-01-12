using FodboldApp.Stack;
using FodboldApp.ViewModel;
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
        

        public MainPage()
        {
            InitializeComponent();

            //new MainViewModel(PlaceHolder);
            BindingContext = this;

            //ResetIconTint();

            //News_Tapped(news, new EventArgs ());

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}