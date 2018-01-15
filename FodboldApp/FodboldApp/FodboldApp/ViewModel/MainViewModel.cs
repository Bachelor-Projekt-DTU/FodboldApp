using FodboldApp.Stack;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class MainViewModel
    {
        public static CustomStack stack = CustomStack.Instance;
        public static ContentPage CurrentPage;
        public static ContentView MainPageContent;

        Color SelectedColor = Color.FromHex("#315baa");
        Color UnSelectedColor = Color.FromHex("#545454");

        public Color NewsIconColor { get; } = Color.FromHex("#315baa");
        public Color PlayerIconColor { get; }
        public Color MatchIconColor { get; }
        public Color TournamentIconColor { get; }
        public Color HistoryIconColor { get; }

        public MainViewModel(ContentView mainPage)
        {
            NewsIconColor = SelectedColor;
            PlayerIconColor = UnSelectedColor;
            MatchIconColor = UnSelectedColor;
            TournamentIconColor = UnSelectedColor;
            HistoryIconColor = UnSelectedColor;
            MainPageContent = mainPage;

        }

        public static void ButtonPressPage(int i)
        {
            switch(i)
            {
                case 0:
                    CurrentPage = (ContentPage) stack.NewsContent.CurrentPage;
                    break;
                case 1:
                    CurrentPage = (ContentPage) stack.PlayerContent.CurrentPage;
                    break;
                case 2:
                    CurrentPage = (ContentPage) stack.MatchContent.CurrentPage;
                    break;
                case 3:
                    CurrentPage = (ContentPage) stack.TournamentContent.CurrentPage;
                    break;
                case 4:
                    CurrentPage = (ContentPage) stack.HistoryContent.CurrentPage;
                    break;
            }
            ChangePage();
        }

        public static void ChangePage()
        {
            MainPageContent.Content = CurrentPage.Content;
        }
    }
}
