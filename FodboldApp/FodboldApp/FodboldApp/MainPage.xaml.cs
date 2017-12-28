using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FodboldApp
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
		{
			InitializeComponent();

            // Sætter data i listviewet
            clubList.ItemsSource = new string[]{"BK Frem", "Klub 2", "Klub 3", "Klub 4", "Klub 5"};

            // Sætter farven til linjen mellem items i listviewt
            clubList.SeparatorColor = Color.Black;

            // Listviewet skal reduceres for at fjerne tomrum: HeightRequest = (#items * itemHeight) +(Standardhøjde + #items)
            clubList.HeightRequest = (5 * clubList.RowHeight) + (10 * 22.5);

            continueBtn.Clicked += OnBtnClick;
        }

        private void OnBtnClick(object sender, EventArgs e)
        {
            NavigationPage nav = new NavigationPage(new Header());
            App.Navigation = nav;
            Application.Current.MainPage = App.Navigation;
        }
    }
}
