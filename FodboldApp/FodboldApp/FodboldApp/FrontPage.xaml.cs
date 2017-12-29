﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FodboldApp
{
	public partial class FrontPage : ContentPage
	{
        public FrontPage()
		{
			InitializeComponent();

            // Sætter data i listviewet

            ObservableCollection<Clubs> clubsCollection = new ObservableCollection<Clubs>();

                clubList.ItemsSource = clubsCollection;

                clubsCollection.Add(new Clubs { ClubName = "BK Frem" });
                clubsCollection.Add(new Clubs { ClubName = "Klub 2" });
                clubsCollection.Add(new Clubs { ClubName = "Klub 3" });
                clubsCollection.Add(new Clubs { ClubName = "Klub 4" });
                clubsCollection.Add(new Clubs { ClubName = "Klub 5" });
            
            // Sætter farven til linjen mellem items i listviewt
            clubList.SeparatorColor = Color.Black;

            // Listviewet skal reduceres for at fjerne tomrum: HeightRequest = (#items * itemHeight) +(Standardhøjde + #items)
            clubList.HeightRequest = (5 * clubList.RowHeight) + (10 * 22.5);

            continueBtn.Clicked += OnBtnClick;
        }

        private void OnBtnClick(object sender, EventArgs e)
        {
            NavigationPage nav = new NavigationPage(new MainPage());
            App.Navigation = nav;
            Application.Current.MainPage = App.Navigation;
        }
    }
}