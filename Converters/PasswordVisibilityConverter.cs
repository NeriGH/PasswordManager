using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Converters
{
    public class PasswordVisibilityConverter : IValueConverter
    {
        // Implementation code goes here...
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isPasswordVisible && isPasswordVisible)
            {
                return parameter.ToString();
            }
            else
            {
                string password = value as string;
                if (!string.IsNullOrEmpty(password))
                {
                    return new string('\u2022', password.Length); // Use '\u25CF' if you prefer a solid dot
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
