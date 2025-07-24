using System;
using System.Globalization;

namespace MiMascota.Converters
{
    public class CountToHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Manejo de valores nulos
            if (value is int count)
            {
                int rows = count / 3 + (count % 3 > 0 ? 1 : 0);
                return rows * 120; // 100 de imagen + paddings
            }
            return 0; // Valor por defecto si no es int
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}