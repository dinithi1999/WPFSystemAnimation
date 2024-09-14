using System;
using System.Globalization;
using System.Windows.Data;

namespace AnimPart1.UC_OtherAnima.LOCAnimation
{
    public class DistanceConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double xValue)
            {
                // Map value from 0-900 to 0-100
                double convertedValue = xValue * -1 / 530 * 99;
                return convertedValue.ToString("0"); // Format as integer
            }
            return "0";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string strValue && double.TryParse(strValue, out double numericValue))
            {
                // Map value from 0-100 back to 0-900
                return numericValue / 99 * 530;
            }
            return 0;
        }
    }
}
