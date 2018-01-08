using System.Linq;
using FodboldApp.Colorization;
using FodboldApp.Data;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OverFiftyGoals : ContentPage
	{
		public OverFiftyGoals ()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var items = OverFiftyGoalsData.Players;
            var itemGrid = new Grid { RowSpacing = 0, ColumnSpacing = 0 };

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
                Text = "Mål/Kampe",
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
                    HeightRequest = 50,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 1, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Goals_Games.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = ColoringLogic.GetColor(j),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HeightRequest = 50,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 2, j);
            }
            InitializeComponent();

            pageLayout.Children.Add(itemGrid);

        }
    }
}