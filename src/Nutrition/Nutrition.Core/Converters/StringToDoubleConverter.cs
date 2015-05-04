using Cirrious.CrossCore.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Core.Converters
{
    public class StringToDoubleConverter : MvxValueConverter<double?, string>
    {

        protected override string Convert(double? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!value.HasValue)
                return null;

            return value.Value.ToString(culture);
        }

        protected override double? ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            try
            {
                return double.Parse(value, culture);
            }
            catch
            {
                return null;
            }
        }
    }
}
