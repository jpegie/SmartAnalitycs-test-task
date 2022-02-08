using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace database_manager.Converters
{
    internal class NewFieldConverter : IMultiValueConverter
    {
        static List<FieldDataType> types = new List<FieldDataType>();
        static NewFieldConverter()
        {
            foreach (FieldDataType dataType in Enum.GetValues(typeof(FieldDataType)))
                types.Add(dataType);
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            object[]array = new object[values.Length];
            for (int i = 0; i < values.Length; ++i)
                array[i] = values[i];
            return array;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
