using FodboldApp.BoxDesigns;
using FodboldApp.Colorization;
using FodboldApp.Model;
using FodboldApp.ViewModel;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerDescription : ContentPage
    {
        static PlayerVM Player = new PlayerVM();

        protected override bool OnBackButtonPressed()
        {
            HeaderVM.BackButtonPressed();
            return true;
        }

        public PlayerDescription()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //List<string> design = PlayerDescriptionDesign.GetDesign(Player);

            //ImageURL = design[0];
            //Name = design[1];
            //Description = design[design.Count - 1];
            //InitializeComponent();
            //BindingContext = this;

            //NavigationPage.SetHasNavigationBar(this, false);

            //for (int i = 0; i < StatsRows; i++)
            //{
            //    statGrid.RowDefinitions.Add(new RowDefinition());
            //}
            //for (int i = 0; i < DescriptionRows; i++)
            //{
            //    descriptionGrid.RowDefinitions.Add(new RowDefinition());
            //}

            //int j = 1;
            //for (int i = 0; i < StatsRows; i++)
            //{
            //    j++;
            //    statGrid.Children.Add(new Label()
            //    {
            //        BackgroundColor = ColoringLogic.GetColor(i),
            //        WidthRequest = 5,
            //        VerticalOptions = LayoutOptions.FillAndExpand,
            //        HorizontalOptions = LayoutOptions.Start
            //    }, 0, i);
            //    statGrid.Children.Add(new Label
            //    {
            //        Text = design[j],
            //        FontSize = 1.2 * Device.GetNamedSize(NamedSize.Small, typeof(Label)),
            //        //WidthRequest = 50,
            //        HorizontalOptions = LayoutOptions.FillAndExpand,
            //        BackgroundColor = ColoringLogic.GetColor(i),
            //        //HorizontalOptions = LayoutOptions.FillAndExpand
            //    }, 1, i);
            //}

            //j++;
            //descriptionGrid.Children.Add(new Label()
            //{
            //    BackgroundColor = ColoringLogic.GetColor(0),
            //    WidthRequest = 5,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.Start
            //}, 0, 0);
            //descriptionGrid.Children.Add(new Label()
            //{
            //    BackgroundColor = ColoringLogic.GetColor(0),
            //    WidthRequest = 5,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.Start
            //}, 2, 0);
            //descriptionGrid.Children.Add(new Label
            //{
            //    Text = design[j],
            //    FontSize = 1.2 * Device.GetNamedSize(NamedSize.Small, typeof(Label)),
            //    //WidthRequest = 50,
            //    BackgroundColor = ColoringLogic.GetColor(0),
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    //HeightRequest = (1.5 * Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
            //}, 1, 0);

            //descriptionGrid.Children.Add(new Label()
            //{
            //    BackgroundColor = ColoringLogic.GetColor(1),
            //    WidthRequest = 5,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.Start
            //}, 0, 1);
            //descriptionGrid.Children.Add(new Label()
            //{
            //    BackgroundColor = ColoringLogic.GetColor(1),
            //    WidthRequest = 5,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.Start
            //}, 2, 1);
            //j++;
            //descriptionGrid.Children.Add(new Label
            //{
            //    Text = design[j],
            //    FontSize = 1.2 * Device.GetNamedSize(NamedSize.Small, typeof(Label)),
            //    //WidthRequest = 50,
            //    BackgroundColor = ColoringLogic.GetColor(1),
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    //HeightRequest = (3 * Device.GetNamedSize(NamedSize.Medium, typeof(Label)))
            //}, 1, 1);

        }
    }
}