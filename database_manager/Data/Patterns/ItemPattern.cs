using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace database_manager.Data
{
    internal class ItemPattern
    {
        ObservableCollection<FieldBase> fields = new ObservableCollection<FieldBase>();
        public List<UiFieldType> UiFieldsTypes
        {
            get
            {
                List<UiFieldType> result = new List<UiFieldType>();
                foreach (FieldBase field in fields)
                    result.Add(field.UiType);
                return result;
            }
        }
        public List<FieldDataType> FieldsDataTypes
        {
            get
            {
                List<FieldDataType> result = new List<FieldDataType>();
                foreach (FieldBase field in fields)
                    result.Add(field.DataType);
                return result;
            }
        }
        public ObservableCollection<FieldBase> Fields
        {
            get => fields;
            set => fields = value;   
        }
        public int FieldsAmount
        {
            get
            {
                return fields.Count;
            }
        }
        
        public bool ContainsFieldTitle(string title)
        {
            foreach(FieldBase field in fields)
            {
                if (field.FieldTitle == title)
                    return true;
            }
            return false;
        }
        public void AddField(FieldDataType dataType, string title)
        {
            if(fields.Count == 0)
            {
                fields.Add(new FieldBase()
                {
                    FieldTitle = title,
                    IsKey = true,
                    UiType = FieldDataTypeToUiCaster.Cast[dataType],
                    DataType = dataType
                });
            } 
            else
            {
                fields.Add(new FieldBase()
                {
                    FieldTitle = title,
                    IsKey = false,
                    UiType = FieldDataTypeToUiCaster.Cast[dataType],
                    DataType = dataType
                }); ;
            }
        }
        public void RemoveField(string fieldTitle)
        {
            for(int i=0;i<FieldsAmount ; ++i)
            {
                if (fields[i].FieldTitle == fieldTitle)
                {
                    fields.RemoveAt(i);
                    return;
                }
            }
        }
        
    }
}
