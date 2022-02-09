using database_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static database_manager.Viewmodels.RelayCommands;

namespace database_manager.Viewmodels
{
    internal class DataBaseViewModel
    {
        DataBaseModel dbModel;
        TableModel tableModel;
        public DataBaseViewModel(DataBaseModel dbModel, TableModel tableModel)
        {
            this.dbModel = dbModel;
            this.tableModel = tableModel;
        }
        public ObservableCollection<string> Tables
        {
            get => dbModel.Tables;
            set => dbModel.Tables = value;
        }
        public void DisplayException(Exception ex)
        {
            MessageDisplay.DisplayException(ex);
        }
        public void DisplayMessage(string message)
        {
            MessageDisplay.DisplayMessage(message);
        }

        public bool Connected
        {
            get => dbModel.Connected;
        }
        public ICommand OpenSelectedTableCommand
        {
            get
            {
                return new RelayCommand<object>(tableModel.OpenSelectedTable);
            }
        }

        public ICommand RemoveSelectedTableCommand
        {
            get
            {
                return new RelayCommand<object>(dbModel.RemoveTableByTitle);
            }
        }
        public ICommand CreateTableCommand
        {
            get
            {
                return new RelayCommand<object>(dbModel.CreateTable);
            }
        }

    }

}
