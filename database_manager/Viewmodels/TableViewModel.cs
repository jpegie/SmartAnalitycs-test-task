using database_manager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database_manager.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static database_manager.Viewmodels.RelayCommands;
using System.Collections.ObjectModel;

namespace database_manager.Viewmodels
{
    internal class TableViewModel
    {
        TableModel tableModel;
        public TableViewModel(TableModel tableModel)
        {
            this.tableModel = tableModel; 
        }
        public string TableTitle
        {
            get => tableModel.TableTitle;
            set => tableModel.TableTitle = value;
        }
        public string KeyColumnTitle
        {
            get => tableModel.KeyColumnTitle;
            set => tableModel.KeyColumnTitle = value;
        }
        public ObservableCollection<FieldBase> Fields
        {
            get => tableModel.Fields;
            set => tableModel.Fields = value;
        }
        public ObservableCollection<Item> Items
        {
            get => tableModel.Items;
            set => tableModel.Items = value;
        }
        public ICommand AddItemCommand
        {
            get
            {
                return new RelayCommand<object>(tableModel.AddEmptyItem);
            }
        }
        public ICommand RemoveItemCommand
        {
            get
            {
                return new RelayCommand<object>(tableModel.RemoveItem);
            }
        }
        public ICommand RemoveSelectedFieldCommand
        {
            get
            {
                return new RelayCommand<object>(tableModel.RemoveField);
            }
        }
        public ICommand AddFieldCommand
        {
            get
            {
                return new RelayCommand<object[]>(tableModel.AddField);
            }
        }
        /*public void RemoveColumnByTitle(string columnTitle)
        {
            tableModel.RemoveColumnByTitle(columnTitle);
        }
        public void AddColumn(Column column)
        {
            tableModel.AddColumn(column); 
        }*/

    }

}
