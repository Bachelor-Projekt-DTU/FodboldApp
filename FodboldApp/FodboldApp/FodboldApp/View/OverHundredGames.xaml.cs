using FodboldApp.Globals;
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
	public partial class OverHundredGames : ContentPage
	{
        protected override bool OnBackButtonPressed()
        {
            HeaderVM.BackButtonPressed();
            return true;
        }

        public OverHundredGames ()
		{
            InitializeComponent();
        }
    }
}