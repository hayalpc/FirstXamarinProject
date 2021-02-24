using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FirstXamarinProject.Converter
{
    public class BoolToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isValid = (bool)value;
            if (isValid)
                return ImageSource.FromResource("FirstXamarinProject.Images.ok.png");
            else
                return ImageSource.FromResource("FirstXamarinProject.Images.cancel.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
