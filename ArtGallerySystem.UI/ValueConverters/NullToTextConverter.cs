using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace ArtGallerySystem.UI.ValueConverters
{
    public class NullToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return parameter?.ToString() ?? "N/A";
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
