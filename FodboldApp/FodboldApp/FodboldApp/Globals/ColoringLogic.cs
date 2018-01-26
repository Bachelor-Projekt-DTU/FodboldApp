using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.Globals
{
    class ColoringLogic
    {
        public static Color AppPrimary { get; set; } = Color.FromHex("#fb433c");
        public static Color AppSecondary { get; set; } = Color.FromHex("#315baa");
        public static Color AppText { get; set; } = Color.FromHex("#243f73");

        private static Color ListPrimary = Color.FromHex("#ffffff");
        private static Color ListSecondary = Color.FromHex("#f0f0f0");

        public static void InitColors(int i)
        {
            switch(i)
            {
                case 0:
                    AppPrimary = Color.FromHex("#fb433c"); ;
                    AppSecondary = Color.FromHex("#315baa");
                    break;
                case 1:
                    AppPrimary = Color.FromHex("#fb433c"); ;
                    AppSecondary = Color.FromHex("#315baa");
                    break;
                case 2:
                    AppPrimary = Color.FromHex("#fb433c"); ;
                    AppSecondary = Color.FromHex("#315baa");
                    break;
                case 3:
                    AppPrimary = Color.FromHex("#fb433c"); ;
                    AppSecondary = Color.FromHex("#315baa");
                    break;
                case 4:
                    AppPrimary = Color.FromHex("#fb433c"); ;
                    AppSecondary = Color.FromHex("#315baa");
                    break;
            }
        }

        public static Color GetColor(int i)
        {
            if (i % 2 == 0) return ListSecondary;
            return ListPrimary;
        }
    }
}
