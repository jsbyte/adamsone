using System;
using System.Globalization;
using System.Windows.Data;
using MahApps.Metro.Controls;

namespace Adamsone.Converters
{
    public class SelectedMenuItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is HamburgerMenuIconItem menuItem ? menuItem.Tag : value;
        }
    }
}
