using database_manager.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace database_manager.Data
{
    internal static class TypesContainer
    {
        static List<string> types = new List<string>();
        static TypesContainer()
        {
            types = Enum.GetValues(typeof(FieldDataType)).Cast<FieldDataType>().Select(el=>el.ToString()).ToList();
        }
        static public List<string> Types
        {
            get => types;
        }
    }
}
