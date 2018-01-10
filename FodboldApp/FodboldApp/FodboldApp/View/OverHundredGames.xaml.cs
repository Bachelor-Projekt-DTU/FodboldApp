using FodboldApp.Colorization;
using FodboldApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OverHundredGames : ContentPage
	{
		public OverHundredGames ()
		{
            NavigationPage.SetHasNavigationBar(this, false);

            var items = OverHundredGamesData.Players;
            var itemGrid = grid;

            // defining the number of rows according to the number of items
            for (int i = 0; i < items.Count + 1; i++)
            {
                itemGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            // defining number of columns
            for (int i = 0; i < 3; i++)
            {
                itemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = ColoringLogic.GetColor(0),
                Text = "Navn",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 0, 0);
            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = ColoringLogic.GetColor(0),
                Text = "Periode",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 1, 0);
            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = ColoringLogic.GetColor(0),
                Text = "Kampe",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 2, 0);

            for (int i = 0; i < items.Count; i++)
            {
                int j = i + 1;

                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Name.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = ColoringLogic.GetColor(j),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 0, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Period.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = ColoringLogic.GetColor(j),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    HeightRequest = 50,
                    VerticalTextAlignment = TextAlignment.Center
                }, 1, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Games.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = ColoringLogic.GetColor(j),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    HeightRequest = 50,
                    VerticalTextAlignment = TextAlignment.Center
                }, 2, j);
            }
            InitializeComponent();

            pageLayout.Children.Add(itemGrid);

        }
    }
}