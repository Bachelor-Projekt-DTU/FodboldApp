using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.Colorization
{
    class ColoringLogic
    {
        private static Color AppPrimary = Color.FromHex("#fb433c");
        private static Color AppSecondary= Color.FromHex("#315baa");
        private static Color AppText = Color.FromHex("#243f73");

        private static Color ListPrimary = Color.FromHex("#ffffff");
        private static Color ListSecondary = Color.FromHex("#f0f0f0");

        public static void InitColors(int i)
        {
            switch(i)
            {
                
            }
        }

        public static Color GetColor(int i)
        {
            if (i % 2 == 0) return ListPrimary;
            return ListSecondary;
        }
    }
}
