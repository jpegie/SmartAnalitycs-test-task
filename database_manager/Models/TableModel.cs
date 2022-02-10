using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using database_manager.Data;

namespace database_manager.Models
{
    internal class TableModel : INotifyPropertyChanged
    {
        //TODO: добавить страничную навигацию в ItemsUserControl (подгружать по N записей, а не сразу все)

        ItemPattern itemPattern = new ItemPattern();
        ObservableCollection<Item> items = new ObservableCollection<Item>();
        DataBaseModel dbModel;

        string title = "";
        string keyFieldTitle = "";

        public TableModel(DataBaseModel dbModel)
        {
            this.dbModel = dbModel;
            this.PropertyChanged += KeyListener.ListenRemovedField;
        }
        public ObservableCollection<Item> Items
        {
            get => items;
            set => items = value;
        }
        public ItemPattern ItemPattern
        {
            get => itemPattern;
        }
        public string TableTitle
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("TableTitle");
            }
        }
        public string KeyColumnTitle
        {
            get => keyFieldTitle;
            set
            {
                keyFieldTitle = value;
                OnPropertyChanged("KeyColumnTitle");
            }
        }

        public ObservableCollection<FieldBase> Fields
        {
            get => itemPattern.Fields;
            set => itemPattern.Fields = value;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion

        public void AddEmptyItem(object parameter)
        {
            ObservableCollection<FieldBase> itemFields = new ObservableCollection<FieldBase>();
            for (int field_i = 0; field_i < itemPattern.FieldsAmount; ++field_i)
            {
                FieldDataType field_DataType = itemPattern.FieldsDataTypes[field_i];
                UiFieldType field_UiType = itemPattern.UiFieldsTypes[field_i];
                string field_Title = itemPattern.Fields[field_i].FieldTitle;
                FieldBase newField = new FieldBase()
                {
                    FieldTitle = field_Title,
                    DataType = field_DataType,
                    UiType = field_UiType,
                    Data = FieldDataTypeToObjectCaster.Cast[field_DataType]
                };
                itemFields.Add(newField);
            }

            items.Add(new Item()
            {
                Fields = itemFields
            });

            OnPropertyChanged("Items");
            OnPropertyChanged("Fields");
        }
        public void RemoveItem(object parameter)
        {
            items.RemoveAt((int)parameter);
            OnPropertyChanged("Items");
            OnPropertyChanged("Headers");
        }
        public void AddField(object parameter)
        {
            string field_Title = "empty title";
            FieldDataType field_DataType = FieldDataType.Int;

            if (parameter != null)
            {
                var parameterValues = (object[])parameter;
                field_Title = (string)parameterValues[0];
                field_DataType = (FieldDataType)(parameterValues[1]);
                if (itemPattern.ContainsFieldTitle(field_Title) == true)
                    return;
            }
            else return;

            itemPattern.AddField(field_DataType, field_Title);

            foreach (Item item in items)
            {
                item.Fields.Add(new FieldBase()
                {
                    FieldTitle = field_Title,
                    DataType = field_DataType,
                    UiType = FieldDataTypeToUiCaster.Cast[field_DataType],
                    Data = FieldDataTypeToObjectCaster.Cast[field_DataType] 
                });
            }

            OnPropertyChanged("Items");
            OnPropertyChanged("Fields");
            OnPropertyChanged("Headers");
        }
        public void RemoveField(object parameter)
        {
            if (parameter == null) return;
            string field_Title = ((FieldBase)parameter).FieldTitle;
            itemPattern.RemoveField((string)field_Title);

            foreach (Item item in items)
            {
                for (int i = 0; i < item.Fields.Count; ++i)
                {
                    if (item.Fields[i].FieldTitle == field_Title)
                    {
                        item.Fields.RemoveAt(i);
                        break;
                    }
                }
            }

            RemovedField = field_Title;
            OnPropertyChanged("RemovedField");
            OnPropertyChanged("Items");
            OnPropertyChanged("Fields");
            OnPropertyChanged("Headers");
        }

        public void OpenSelectedTable(object tableTitle)
        {
            if(tableTitle == null) return;
            TableTitle = tableTitle.ToString();
            //TODO: отправить запрос dbModel на парсинг items from table, а затем put it into view
            dbModel.ParseFieldsTitlesFromTable(tableTitle.ToString());
        }
        public string RemovedField
        { get; set; }
    }
}
