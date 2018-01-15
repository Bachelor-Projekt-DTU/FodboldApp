﻿using FodboldApp.Colorization;
using System.Linq;
using Xamarin.Forms;
using FodboldApp.Model;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class POTY : ContentPage
	{
		public POTY ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            var items = POTYsData.Players;
            var itemGrid = grid;

            // defining the number of rows according to the number of items
            for (int i = 0; i < items.Count + 1; i++)
            {
                itemGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            // defining number of columns
            for (int i = 0; i < 2; i++)
            {
                itemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = ColoringLogic.GetColor(0),
                Text = "ÅR",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            }, 0, 0);
            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = ColoringLogic.GetColor(0),
                Text = "NAVN",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            }, 1, 0);

            for (int i = 0; i < items.Count; i++)
            {
                int j = i + 1;

                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Year,
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = ColoringLogic.GetColor(j),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    HeightRequest = 50,
                    VerticalTextAlignment = TextAlignment.Center
                }, 0, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Name,
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = ColoringLogic.GetColor(j),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    HeightRequest = 50,
                    VerticalTextAlignment = TextAlignment.Center
                }, 1, j);
            }
            pageLayout.Children.Add(itemGrid);
        }
    }
}