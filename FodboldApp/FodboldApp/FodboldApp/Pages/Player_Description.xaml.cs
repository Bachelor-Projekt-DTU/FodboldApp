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
        private int DescriptionRows = 10;
        public string Name { get; }

        public Player_Description ()
		{
            Name = design[0];
            InitializeComponent ();
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

            for (int i = 0; i < StatsRows; i++)
            {
                int j = i + 1;
                statGrid.Children.Add(new Label
                {
                    Text = design[j],
                    HeightRequest = 60,
                    //WidthRequest = 50,
                    BackgroundColor = ColoringLogic.GetColor(i),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                }, 0, i);
            }
            }
        }
}