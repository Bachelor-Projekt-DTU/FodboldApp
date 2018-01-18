﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.View.Interface
{
    class BooleanReverser : IValueConverter
    {

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                    return !(bool)value;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}