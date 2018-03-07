using FodboldApp.Model;
using FodboldApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsPage : ContentPage
	{
        protected override bool OnBackButtonPressed()
        {
            Console.WriteLine("BACK PRESSED");
            ViewModelLocator.HeaderVM.BackButtonPressed();
            return false;
        }

        public NewsPage (NewsModel newsModel)
		{
            InitializeComponent();
            ViewModelLocator.NewsPageVM.NewsModel = newsModel;
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}