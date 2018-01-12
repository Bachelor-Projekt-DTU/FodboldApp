using FodboldApp.Stack;
using Plugin.CrossPlatformTintedImage.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace FodboldApp.ViewModel
{
    class HeaderViewModel
    {
        Color SelectedColor = Color.FromHex("#315baa");
        Color UnSelectedColor = Color.FromHex("#545454");

        public static ICommand TournamentTapped { get; private set; }

        public Color NewsIconColor { get; private set; }
        public Color PlayerIconColor { get; private set; }
        public Color MatchIconColor { get; private set; }
        public Color TournamentIconColor { get; private set; }
        public Color HistoryIconColor { get; private set; }

        public CustomStack stack;

        public HeaderViewModel()
        {
            stack = CustomStack.Instance;

            NewsIconColor = SelectedColor;
            PlayerIconColor = UnSelectedColor;
            MatchIconColor = UnSelectedColor;
            TournamentIconColor = UnSelectedColor;
            HistoryIconColor = UnSelectedColor;

            //Application.Current.MainPage = CustomStack.Instance.TournamentContent;

            TournamentTapped = new Command(() =>
            {
                TournamentIconColor = SelectedColor;
                Console.WriteLine("HEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEY STAPLE GUN");
                //Application.Current.MainPage = CustomStack.Instance.TournamentContent;
            });
        }

        public async void NewsTap()
        {
            if (Application.Current.MainPage == stack.NewsContent)
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                Application.Current.MainPage = stack.NewsContent;
            }
        }

        public async void PlayerTap()
        {
            if (Application.Current.MainPage == stack.PlayerContent)
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                Application.Current.MainPage = stack.PlayerContent;
            }
        }

        public async void MatchTap()
        {
            if (Application.Current.MainPage == stack.MatchContent)
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                Application.Current.MainPage = stack.MatchContent;
            }
        }

        public async void TournamentTap()
        {
            if (Application.Current.MainPage == stack.TournamentContent)
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                Application.Current.MainPage = stack.TournamentContent;
            }
        }

        public async void HistoryTap()
        {
            if (Application.Current.MainPage == stack.HistoryContent)
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                Application.Current.MainPage = stack.HistoryContent;
            }
        }
    }
}
