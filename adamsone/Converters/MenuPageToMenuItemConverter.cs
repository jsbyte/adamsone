using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Adamsone.ViewModels;
using MahApps.Metro.Controls;

namespace Adamsone.Converters
{
    public class MenuPageToMenuItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<MenuPageViewModelBase> nmItemCollection)
            {
                return nmItemCollection.Select(item => new HamburgerMenuIconItem
                {
                    Tag = item,
                    Icon = item.Icon,
                    Label = item.Label
                });
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
