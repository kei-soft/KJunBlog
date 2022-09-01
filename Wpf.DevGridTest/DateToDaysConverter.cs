using System;
using System.Globalization;
using System.Windows.Data;

namespace Wpf.DevGridTest
{
    internal class DateToDaysConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (System.Convert.ToDateTime(value) - DateTime.Now).Days;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
