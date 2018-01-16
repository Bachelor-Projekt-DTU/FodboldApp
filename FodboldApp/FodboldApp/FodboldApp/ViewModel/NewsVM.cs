using FodboldApp.Stack;
using FodboldApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class NewsVM
    {
        public ICommand NewsCommand { get; private set; }
        public string TestText { get; } = "AAAAAAAAAAAAAAAY";

        public NewsVM()
        {
            Console.WriteLine("DIPSET CITY");
            NewsCommand = new Command(News_Tapped);
        }

        void News_Tapped()
        {
            Console.WriteLine("WE ON IT");

            CustomStack.Instance.NewsContent.Navigation.PushAsync(new NewsPage());
            HeaderVM.UpdateContent();
        }
    }
}
