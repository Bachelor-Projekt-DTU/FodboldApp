using Xamarin.Forms;

namespace FodboldApp.Globals
{
    class ColoringLogic
    {
        //currently sets BK Frem colors instead of basing it on the chosen club
        public static Color AppPrimary { get; set; } = Color.FromHex("#fb433c");
        public static Color AppSecondary { get; set; } = Color.FromHex("#315baa");
        public static Color AppText { get; set; } = Color.FromHex("#243f73");

        private static Color ListPrimary = Color.FromHex("#ffffff");
        private static Color ListSecondary = Color.FromHex("#f0f0f0");

        //logic for changing color based on clubs, currently not in use
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

        //alternating white/grey for lists
        public static Color GetColor(int i)
        {
            if (i % 2 == 0) return ListSecondary;
            return ListPrimary;
        }
    }
}
