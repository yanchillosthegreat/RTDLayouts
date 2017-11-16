using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using RTDLayouts.Models;

namespace RTDLayouts.Converters
{
    public class DateTimeQuotumFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is DateTimeQuotum quotum)) return value;

            return string.Format("с {0}:00 до {1}:00       {2}", quotum.LoverValue, quotum.UpperValue,
                quotum.DeliveryCost.ToString("N0", new NumberFormatInfo { NumberGroupSeparator = " " }) + " р.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
