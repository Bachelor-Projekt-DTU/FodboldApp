using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FodboldApp.Data;
using System.Net;
using System.IO;
using System;

namespace FodboldApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Players : ContentPage
    {
        public Players()
        {
            InitializeComponent();
        }
    }
}