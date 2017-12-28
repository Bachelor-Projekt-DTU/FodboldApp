using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FodboldApp
{
	public partial class Header : ContentPage
	{
		public Header ()
		{
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}