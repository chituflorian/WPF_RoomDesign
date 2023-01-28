using System;
using System.Globalization;
using System.Windows.Data;
using WPF_Design.Models;

namespace WPF_Design.BusinessLogicLayer.Converters
{
    public class SpecialPropertyNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value switch
            {
                Chair => "Material:",
                Cooker => "Type:",
                Desk => "Material:",
                LivingRoomTable => "Material:",
                Table => "Material:",
                TV => "Brand:",
                _ => string.Empty
            };

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
