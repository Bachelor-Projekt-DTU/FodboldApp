using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FodboldApp.Model;
using System.Net;
using System.IO;
using System;
using FodboldApp.View;
using FodboldApp.ViewModel;

namespace FodboldApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Players : ContentPage
    {
        public Players()
        {
            InitializeComponent();
            BindingContext = new PlayerVM();
        }
    }
}