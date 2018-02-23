using FodboldApp.Stack;
using FodboldApp.ViewModel;
using Plugin.CrossPlatformTintedImage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FodboldApp
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {


            InitializeComponent();

            HeaderVM.SetContent(pageContent);
            ViewModelLocator.HeaderVM.CreateStack();
            ViewModelLocator.HeaderVM.NewsTap();
            Task.Run(()=>NoInternetVM.IsConnectedOnMainPage(null));

            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override bool OnBackButtonPressed()
        {
            HeaderVM.BackButtonPressed();
            return true;
        }
    }
}