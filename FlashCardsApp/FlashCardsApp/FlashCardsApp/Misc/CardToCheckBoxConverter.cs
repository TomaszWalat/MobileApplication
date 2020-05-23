using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FlashCardsApp.Misc
{
    public class CardToCheckBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("Value is: " + value.ToString());
            Console.WriteLine("TargetType is: " + targetType.Name);
            Console.WriteLine("Parameter is: " + parameter.ToString());
            Console.WriteLine("Culture is: " + culture.Name);

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
