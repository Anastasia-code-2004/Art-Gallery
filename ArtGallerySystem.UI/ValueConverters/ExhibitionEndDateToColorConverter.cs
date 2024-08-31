using System;
using System.Globalization;


namespace ArtGallerySystem.UI.ValueConverters
{
    public class ExhibitionEndDateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime endDate)
            {
                return endDate < DateTime.Now ? Colors.LightGray : Colors.White;
            }
            return Colors.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
