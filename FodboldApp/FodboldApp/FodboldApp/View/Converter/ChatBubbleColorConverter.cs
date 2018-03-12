using System;
using Xamarin.Forms;

namespace FodboldApp.View.Converter
{
    class ChatBubbleColorConverter : IValueConverter
    {

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                    return Globals.ColoringLogic.AppPrimary;
            }
            return Globals.ColoringLogic.AppSecondary;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
