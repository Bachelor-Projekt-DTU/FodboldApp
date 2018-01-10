using FodboldApp.ViewModel;
using System;
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

            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new ClubVM();

            // Listviewet skal reduceres for at fjerne tomrum: HeightRequest = (#items * itemHeight) +(Standardhøjde + #items)
            clubList.HeightRequest = (5 * clubList.RowHeight) + (10 * 22.5);

            continueBtn.Clicked += OnBtnClick;
        }

        private void OnBtnClick(object sender, EventArgs e)
        {
            NavigationPage nav = new NavigationPage(new MainPage());
            App.Navigation = nav;
            Application.Current.MainPage = nav;
        }

        Label previousLabel;
        private async void OnItemSelected(object sender, EventArgs e)
        {
            var entity = ((Label)sender);
            if (previousLabel != null) previousLabel.BackgroundColor = Color.White;
            entity.BackgroundColor = Color.Red;
            previousLabel = entity;
        }
    }
}
