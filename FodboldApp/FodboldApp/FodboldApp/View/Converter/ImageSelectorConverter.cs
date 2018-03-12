using System;
using Xamarin.Forms;

namespace FodboldApp.View.Converter
{
    class ImageSelectorConverter : IValueConverter
    {

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                switch (value)
                {
                    case "Yellow Card": return "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png";
                    default: return "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png";
                }
            }
            return "https://icon-icons.com/icons2/553/PNG/96/footbal_icon-icons.com_53569.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
