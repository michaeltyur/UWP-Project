using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace GardianNewsApp.UWP.Converters
{
    public class HtmlToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string text = StripTagsRegex((string)value);
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>|", string.Empty);
        }
    }
}
