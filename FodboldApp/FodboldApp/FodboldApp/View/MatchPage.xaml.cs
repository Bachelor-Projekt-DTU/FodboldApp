using FodboldApp.Model;
using FodboldApp.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MatchPage : ContentPage
	{
		public MatchPage (MatchModel match)
		{
            InitializeComponent();
            ViewModel.ViewModelLocator.MatchPageVM.Match = match;
        }
    }
}