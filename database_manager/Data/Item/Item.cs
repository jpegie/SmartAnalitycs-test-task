using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace database_manager.Data
{
    internal class Item
    {
        public ObservableCollection<FieldBase> Fields
        {
            get; set;
        }
    }
}
