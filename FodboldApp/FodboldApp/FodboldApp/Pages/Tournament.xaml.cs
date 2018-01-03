using FodboldApp.Data;
using ImageCircle.Forms.Plugin.Abstractions;
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
	public partial class Tournament : ContentPage
	{
		public Tournament ()
        {
            var items = PlayersData.Players;
            var itemGrid = new Grid { RowSpacing = 0, ColumnSpacing = 0 };

            // defining the number of rows according to the number of items
            for (int i = 0; i < items.Count+1; i++)
            {
                itemGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            // defining number of columns
            for (int i = 0; i < PlayersData.ATTRIBUTE_COUNT; i++)
            {
                itemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = Color.FromHex("#ffffff"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center
            }, 0, 0);

            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = Color.FromHex("#ffffff"),
                Text = "KAMPE",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 1, 0);
            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = Color.FromHex("#ffffff"),
                Text = "MÅL",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 2, 0);
            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = Color.FromHex("#ffffff"),
                Text = "ASSIST",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 3, 0);
            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = Color.FromHex("#ffffff"),
                Text = "MVP",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 4, 0);
            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = Color.FromHex("#ffffff"),
                Text = "CLEAN SHEET",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 5, 0);

            for (int i = 0; i < items.Count; i++)
            {
                int j = i + 1;
                itemGrid.Children.Add(new CircleImage
                {
                    Source = items[i].ImageURL,
                    HeightRequest = 60,
                    //WidthRequest = 50,
                    Aspect = Aspect.AspectFill,
                    BackgroundColor = GetColor(i),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                }, 0, j);
                
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Matches.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = GetColor(i),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 1, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Goals.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = GetColor(i),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 2, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Assists.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = GetColor(i),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 3, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].MVP.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = GetColor(i),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 4, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Clean_Sheet.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = GetColor(i),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 5, j);
            }



            InitializeComponent();

            pageLayout.Children.Add(itemGrid);

        }

        private Color GetColor(int i)
        {
            if (i % 2 == 0) return Color.FromHex("#f0f0f0");
            return Color.FromHex("#ffffff");
        }

       /* private Image CropImage()
        {
            Image croppedImage = new Image();
            croppedImage.WidthRequest = 200;
            CroppedBitmap cb = new CroppedBitmap(
   (BitmapSource)this.Resources["masterImage"],
   new Int32Rect(30, 20, 105, 50));       //select region rect
            croppedImage.Source = cb;
        }*/
    }
}