using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPF_Design.BusinessLogicLayer.Converters
{
    public class VisibilityToHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool IsObjectSelected = (bool)value;

            return !IsObjectSelected ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
