using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace RTDLayouts.Converters
{
    public class PriceFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is int price))
                return value;

            var priceString = price.ToString();
            var revertedPriceString = Reverse(priceString);
            var formattedRevertedPriceString = Regex.Replace(revertedPriceString, ".{3}", "$0 ");
            var result = Reverse(formattedRevertedPriceString) + " р.";

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
