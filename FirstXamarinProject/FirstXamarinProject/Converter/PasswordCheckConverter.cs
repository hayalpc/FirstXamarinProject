using FirstXamarinProject.Behaviours;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace FirstXamarinProject.Converter
{
    public class PasswordCheckConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var deger = (string)value;
            var email = (Entry)parameter;
            var IsValid = email.Text != null ? Regex.IsMatch(email.Text, EmailBehavior.emailRegex) : false;

            var result = deger.Length > 4 && IsValid ? true : false;

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
