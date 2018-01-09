using FodboldApp.BoxDesigns;
using FodboldApp.Colorization;
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
    public partial class Player_Description : ContentPage
    {
        static PlayersData Player = PlayersData.Players[9];
        List<string> design = PlayerDescriptionDesign.GetDesign(Player);

        private int StatsRows = 10;
        private int DescriptionRows = 2;
        public string Name { get; }
        public string Description { get; }

        public Player_Description()
        {
            Name = design[1];
            Description = design[design.Count - 1];
            InitializeComponent();
            BindingContext = this;

            NavigationPage.SetHasNavigationBar(this, false);

            for (int i = 0; i < StatsRows; i++)
            {
                statGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < DescriptionRows; i++)
            {
                descriptionGrid.RowDefinitions.Add(new RowDefinition());
            }

            int j = 1;
            for (int i = 0; i < StatsRows; i++)
            {
                j++;
                statGrid.Children.Add(new Label
                {
                    Text = design[j],
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    //WidthRequest = 50,
                    BackgroundColor = ColoringLogic.GetColor(i),
                    //HorizontalOptions = LayoutOptions.FillAndExpand
                }, 0, i);
            }
            for (int i = 0; i < DescriptionRows; i++)
            {
                j++;
                descriptionGrid.Children.Add(new Label
                {
                    Text = design[j],
                    //WidthRequest = 50,
                    BackgroundColor = ColoringLogic.GetColor(i),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                }, 0, i);
            }
        }
    }
}