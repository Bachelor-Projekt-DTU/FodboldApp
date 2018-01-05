using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.Colorization
{
    class ColoringLogic
    {
        private static Color Primary = Color.FromHex("#ffffff");
        private static Color Secondary = Color.FromHex("#f0f0f0");

        public static void InitColors(int i)
        {
            switch(i)
            {

            }
        }

        public static Color GetColor(int i)
        {
            if (i % 2 == 0) return Primary;
            return Secondary;
        }
    }
}
