using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_manager.Data
{
    internal static class FieldDataTypeToObjectCaster
    {
        public static Dictionary<FieldDataType, object> Cast = new Dictionary<FieldDataType, object>()
        {
            {FieldDataType.Int, (int)0},
            {FieldDataType.Float, (float)6.66f },
            {FieldDataType.String, (string)"empty string" },
            {FieldDataType.DateTime, (DateTime) DateTime.Now }
        };
    }
}
