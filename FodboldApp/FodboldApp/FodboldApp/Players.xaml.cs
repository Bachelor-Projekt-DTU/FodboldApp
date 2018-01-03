using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Players : ContentPage
	{
		public Players ()
		{
			InitializeComponent ();

            //Add tap handler to grid_Element0:
            TapGestureRecognizer tapEvent = new TapGestureRecognizer();

            //Connect event handler (Players_Tapped) to TapGestureRecognizer:
            tapEvent.Tapped += Players_Tapped;

            //Add TapGestureRecognizer to grid_Element0:
            grid_Element0.GestureRecognizers.Add(tapEvent);
        

        void Players_Tapped(object sender, EventArgs e)
        {
            Console.WriteLine("Players_Tapped");
        }
    }
    }
}