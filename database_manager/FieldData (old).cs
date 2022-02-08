using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace database_manager.Data
{
    /*internal class FieldData
    {
        object data;
        Type dataType;

        public object Data
        {
            get => data;
            set
            {
                Type contextType = value.GetType();
                if (contextType != typeof(string))
                {
                    PropertyInfo prop = contextType.GetProperty("Data");
                    data = prop.GetValue(value);
                }
                else
                {
                    data = value;
                }
            }
        }
        public Type DataType
        {
            get => dataType;
            set => dataType = value;
        }
        public UiFieldType UiType
        { get; set; }
    }*/
}
