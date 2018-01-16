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

            HeaderVM vm = new HeaderVM();

            vm.SetContent(pageContent);

            NavigationPage.SetHasNavigationBar(this, false);

            vm.NewsTap();
        }
    }
}