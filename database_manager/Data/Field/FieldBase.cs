using System;
using System.ComponentModel;

namespace database_manager.Data
{
    internal class FieldBase : INotifyPropertyChanged
    {
        string title = "";
        object data;
        bool isKey = false;

        Type type = typeof(object);
        UiFieldType uiType;
        FieldDataType dataType;
        
        public FieldBase()
        {
            KeyListener.Connect(this);
            this.PropertyChanged+=KeyListener.ListenKey;
        }
        public UiFieldType UiType
        {
            get => uiType;
            set => uiType = value;
        }
        public FieldDataType DataType
        {
            get => dataType;
            set
            {
                dataType = value;
                UiType = FieldDataTypeToUiCaster.Cast[dataType];
                OnPropertyChanged("Fields");
                OnPropertyChanged("Items");
            }
        }
        public object Data
        {
            get
            {
                return data;
            }
            set
            {

                if (data == null)
                {
                    data = value;
                    type = data.GetType();
                }
                else
                {
                    try
                    {
                        var convertedData = Convert.ChangeType(value, type);
                        data = convertedData;
                    }
                    catch (Exception) { };
                }
            }
        }
        public string FieldTitle
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("FieldTitle");
            }
        }
        public bool IsKey
        {
            get => isKey;
            set
            {
                isKey = value;
                OnPropertyChanged("IsKey");
            }
        }
        public bool IsKeyNoNotify
        {
            get => isKey;
            set => isKey = value;
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
    }
}
