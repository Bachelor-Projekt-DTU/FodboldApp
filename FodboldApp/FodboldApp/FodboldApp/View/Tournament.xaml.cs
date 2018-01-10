using FodboldApp.Colorization;
using FodboldApp.Model;
using FodboldApp.ViewModel;
using ImageCircle.Forms.Plugin.Abstractions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Tournament : ContentPage
	{
        PlayerVM vm = new PlayerVM();

        public Tournament()
        {
            var items = vm.PlayerList;
            items.RemoveAt(items.Count - 1);

            InitializeComponent();

            // defining the number of rows according to the number of items
            for (int i = 0; i < items.Count-1 + 1; i++)
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
                BackgroundColor = ColoringLogic.GetColor(0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center
            }, 0, 0);

            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = ColoringLogic.GetColor(0),
                Text = "KAMPE",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 1, 0);
            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = ColoringLogic.GetColor(0),
                Text = "MÅL",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 2, 0);
            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = ColoringLogic.GetColor(0),
                Text = "ASSIST",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 3, 0);
            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = ColoringLogic.GetColor(0),
                Text = "MVP",
                TextColor = Color.FromHex("182a5c"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 4, 0);
            itemGrid.Children.Add(new Label()
            {
                BackgroundColor = ColoringLogic.GetColor(0),
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
                    BackgroundColor = ColoringLogic.GetColor(j),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                }, 0, j);

                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Matches.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = ColoringLogic.GetColor(j),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 1, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Goals.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = ColoringLogic.GetColor(j),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 2, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Assists.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = ColoringLogic.GetColor(j),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 3, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].MVP.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = ColoringLogic.GetColor(j),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 4, j);
                itemGrid.Children.Add(new Label()
                {
                    Text = items[i].Clean_Sheet.ToString(),
                    TextColor = Color.FromHex("#182a5c"),
                    BackgroundColor = ColoringLogic.GetColor(j),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 5, j);
            }

            pageLayout.Children.Add(itemGrid);

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