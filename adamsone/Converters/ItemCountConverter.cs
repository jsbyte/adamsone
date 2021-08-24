using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Adamsone.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    [MarkupExtensionReturnType(typeof(ItemCountConverter))]
    public class ItemCountConverter : MarkupExtension, IValueConverter
    {
        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int itemCount)
            {
                if (itemCount > 1)
                {
                    return $"({itemCount} subjects)";
                }

                if (itemCount == 1)
                {
                    return $"({itemCount} subject)";
                }
            }

            return string.Empty;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
