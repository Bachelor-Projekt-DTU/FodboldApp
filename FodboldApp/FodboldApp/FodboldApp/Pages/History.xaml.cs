using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FodboldApp
{
	public partial class History : ContentPage
	{
        public History()
        {
            InitializeComponent();

            //Add tap handler to grid_Element0:
            TapGestureRecognizer tapEvent = new TapGestureRecognizer();

            //Connect event handler (Players_Tapped) to TapGestureRecognizer:
            tapEvent.Tapped += Button_Tapped;

            //Add TapGestureRecognizer to grid_Element0:
            grid_Element0.GestureRecognizers.Add(tapEvent);

            void Button_Tapped(object sender, EventArgs e)
            {
                Console.WriteLine("History button tapped");
            }
        }
    }
}
