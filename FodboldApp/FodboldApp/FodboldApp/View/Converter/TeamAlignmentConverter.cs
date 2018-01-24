using System;
using Xamarin.Forms;

namespace FodboldApp.View.Converter
{
    class TeamAlignmentConverter : IValueConverter
    {

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                if ((int)value == 0)
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