using System;
using Xamarin.Forms;

namespace FodboldApp.View.Converter
{
    //sets the picture of the event
    class ImageSelectorConverter : IValueConverter
    {

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                switch (value)
                {
                    case "Yellow card": return "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b1/Yellow_card.svg/2000px-Yellow_card.svg.png";
                    case "Red card": return "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e7/Red_card.svg/220px-Red_card.svg.png";
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
