using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_manager.Data
{
    internal static class FieldDataTypeToUiCaster
    {
        static public Dictionary<FieldDataType, UiFieldType> Cast = new Dictionary<FieldDataType, UiFieldType>()
        {
            {FieldDataType.Int, UiFieldType.TextBox },
            {FieldDataType.Float, UiFieldType.TextBox },
            {FieldDataType.String, UiFieldType.TextBox },
            {FieldDataType.DateTime, UiFieldType.DateTime}
        };
    }
}
