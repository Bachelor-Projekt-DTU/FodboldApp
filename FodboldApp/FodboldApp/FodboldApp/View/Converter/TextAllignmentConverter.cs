using System;
using Xamarin.Forms;

namespace FodboldApp.View.Converter
{
    //used to align text in event
    class TextAllignmentConverter : IValueConverter
    {

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                    return TextAlignment.End;
            }
            return TextAlignment.Start;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
