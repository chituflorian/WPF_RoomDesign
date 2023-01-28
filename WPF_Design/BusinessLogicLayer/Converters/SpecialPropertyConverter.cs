using System;
using System.Globalization;
using System.Windows.Data;
using WPF_Design.Models;

namespace WPF_Design.BusinessLogicLayer.Converters
{
    public class SpecialPropertyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value switch
            {
                Chair => ((Chair)value).Material,
                Cooker => ((Cooker)value).Type,
                Desk => ((Desk)value).Material,
                LivingRoomTable => ((LivingRoomTable)value).Material,
                Table => ((Table)value).Material,
                TV => ((TV)value).Brand,
                _ => string.Empty
            };


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}