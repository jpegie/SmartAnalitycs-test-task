using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using database_manager.Models;

namespace database_manager.Data
{
    internal static class KeyListener
    {
        static string KeyFieldTitle = "";
        // static public event PropertyChangingEventHandler PropertyChanged;
        static List<FieldBase> clientsFields = new List<FieldBase>();
        static public void Connect(FieldBase clientField)
        {
            clientsFields.Add(clientField);
        }
        static public void ListenKey(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsKey") {
                FieldBase senderField = sender as FieldBase;
                if (senderField != null)
                {
                    if (senderField.IsKey == true || senderField.FieldTitle == KeyFieldTitle)
                    {
                        KeyFieldTitle = senderField.FieldTitle;
                        senderField.IsKeyNoNotify = true;
                        foreach(FieldBase field in clientsFields)
                        {
                            if (field.FieldTitle != KeyFieldTitle)
                            {
                                field.IsKey = false;
                            }
                        }
                    } 
                }
            }
        }
        static public void ListenRemovedField(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RemovedField")
            {
                TableModel tableModel = sender as TableModel;
                if(tableModel != null && tableModel.RemovedField == KeyFieldTitle)
                {
                    clientsFields.RemoveAt(clientsFields.FindIndex(f => f.FieldTitle == tableModel.RemovedField));
                    if(clientsFields.Count > 0)
                    {
                        KeyFieldTitle = clientsFields[0].FieldTitle;
                        clientsFields[0].IsKey = true;
                    }
                    else
                    {
                        KeyFieldTitle = null;
                    }
                }
            }
        }
    }
}
