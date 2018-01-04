using FodboldApp.Data;
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
	public partial class Former_Players : ContentPage
	{
		public Former_Players ()
		{
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            var items = PlayersData.Players;
            var itemGrid = new Grid { RowSpacing = 0, ColumnSpacing = 0 };

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
                BackgroundColor = Color.FromHex("#ffffff"),
                Text = "NAVN",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            }, 0, 0);
            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = Color.FromHex("#ffffff"),
                Text = "POSITION",
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
                    Text = items[i].Name,
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = GetColor(i),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 0, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Posistion,
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = GetColor(i),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 1, j);
            }
            pageLayout.Children.Add(itemGrid);
        }

        private Color GetColor(int i)
        {
            if (i % 2 == 0) return Color.FromHex("#f0f0f0");
            return Color.FromHex("#ffffff");
        }
    }
}