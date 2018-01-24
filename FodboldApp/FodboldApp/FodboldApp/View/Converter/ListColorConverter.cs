using FodboldApp.Colorization;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.View.Converter
{
    class ListColorConverter : IValueConverter
    {

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                return ColoringLogic.GetColor((int)value);
            }
            return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
