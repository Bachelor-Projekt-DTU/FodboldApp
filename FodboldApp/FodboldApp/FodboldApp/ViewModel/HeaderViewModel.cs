using FodboldApp.Pages;
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

        //public static ICommand TournamentTapped { get; private set; }

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

            //TournamentTapped = new Command(() =>
            //{
            //    TournamentIconColor = SelectedColor;
            //    Console.WriteLine("HEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEY STAPLE GUN");
            //    //Application.Current.MainPage = CustomStack.Instance.TournamentContent;
            //});
        }

        public async void NewsTap()
        {
            if (Application.Current.MainPage.Navigation.NavigationStack[0] is News)
            {
                await stack.NewsContent.Navigation.PopToRootAsync();
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                int stackSize = stack.NewsContent.Navigation.NavigationStack.Count;
                Console.WriteLine(stackSize);
                var page = Application.Current.MainPage;
                for(int i = 0; i < stackSize; i++)
                {
                    page.Navigation.InsertPageBefore(stack.NewsContent.Navigation.NavigationStack[i], page.Navigation.NavigationStack[i]);
                }
                
                while(page.Navigation.NavigationStack.Count > stackSize)
                {
                    Console.WriteLine(stackSize);
                    await page.Navigation.PopAsync();
                }
                
            }
        }

        public async void PlayerTap()
        {
            if (Application.Current.MainPage.Navigation.NavigationStack[0] is Players)
            {
                await stack.PlayerContent.Navigation.PopToRootAsync();
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                int stackSize = stack.PlayerContent.Navigation.NavigationStack.Count;
                Console.WriteLine(stackSize);
                var page = Application.Current.MainPage;
                for (int i = 0; i < stackSize; i++)
                {
                    page.Navigation.InsertPageBefore(stack.PlayerContent.Navigation.NavigationStack[i], page.Navigation.NavigationStack[i]);
                }

                while (page.Navigation.NavigationStack.Count > stackSize)
                {
                    Console.WriteLine(stackSize);
                    await page.Navigation.PopAsync();
                }

            }
        }

        public async void MatchTap()
        {
            if (Application.Current.MainPage.Navigation.NavigationStack[0] is Matches)
            {
                await stack.MatchContent.Navigation.PopToRootAsync();
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                int stackSize = stack.MatchContent.Navigation.NavigationStack.Count;
                Console.WriteLine(stackSize);
                var page = Application.Current.MainPage;
                for (int i = 0; i < stackSize; i++)
                {
                    page.Navigation.InsertPageBefore(stack.MatchContent.Navigation.NavigationStack[i], page.Navigation.NavigationStack[i]);
                }

                while (page.Navigation.NavigationStack.Count > stackSize)
                {
                    Console.WriteLine(stackSize);
                    await page.Navigation.PopAsync();
                }

            }
        }

        public async void TournamentTap()
        {
            if (Application.Current.MainPage.Navigation.NavigationStack[0] is Tournament)
            {
                await stack.TournamentContent.Navigation.PopToRootAsync();
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                int stackSize = stack.TournamentContent.Navigation.NavigationStack.Count;
                Console.WriteLine(stackSize);
                var page = Application.Current.MainPage;
                for (int i = 0; i < stackSize; i++)
                {
                    page.Navigation.InsertPageBefore(stack.TournamentContent.Navigation.NavigationStack[i], page.Navigation.NavigationStack[i]);
                }

                while (page.Navigation.NavigationStack.Count > stackSize)
                {
                    Console.WriteLine(stackSize);
                    await page.Navigation.PopAsync();
                }
            }
        }

        public async void HistoryTap()
        {
            if (Application.Current.MainPage.Navigation.NavigationStack[0] is History)
            {
                await stack.HistoryContent.Navigation.PopToRootAsync();
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                int stackSize = stack.HistoryContent.Navigation.NavigationStack.Count;
                Console.WriteLine(stackSize);
                var page = Application.Current.MainPage;
                for (int i = 0; i < stackSize; i++)
                {
                    page.Navigation.InsertPageBefore(stack.HistoryContent.Navigation.NavigationStack[i], page.Navigation.NavigationStack[i]);
                }

                while (page.Navigation.NavigationStack.Count > stackSize)
                {
                    Console.WriteLine(stackSize);
                    await page.Navigation.PopAsync();
                }

            }
        }
    }
}
