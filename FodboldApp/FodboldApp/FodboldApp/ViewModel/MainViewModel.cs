using FodboldApp.Stack;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class MainViewModel
    {
        public CustomStack stack;
        public ContentPage CurrentPage;
        public ContentView MainPageContent;
        
        public MainViewModel(ContentView mainPage)
        {
            stack = new CustomStack();
            this.MainPageContent = mainPage;
        }

        public void ButtonPressPage(int i)
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

        public void ChangePage()
        {
            MainPageContent.Content = CurrentPage.Content;
        }
    }
}
