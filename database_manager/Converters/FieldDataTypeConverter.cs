using database_manager.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace database_manager.Converters
{
    internal class FieldDataTypeConverter : IValueConverter
    {
        static List<FieldDataType> types = new List<FieldDataType>();
        static FieldDataTypeConverter() { 
            foreach(FieldDataType dataType in Enum.GetValues(typeof(FieldDataType)))
                types.Add(dataType);
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int index = types.FindIndex(a=>a == (FieldDataType)value);
            return index;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return types[(int)value];
        }
    }
}
