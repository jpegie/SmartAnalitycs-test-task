using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database_manager.Data;
using database_manager.Viewmodels;

namespace database_manager.Models
{
    interface IDataBase
    {
        string DbTitle { get; }
        List<string> Tables { get; }
        
        bool ParseTables();
        bool RemoveTableByTitle(string tableTitle);
        bool CreateTable(TableModel table);
        
        bool ClearDb();
        bool ClearTableByTitle(string tableTitle);
    }

    internal class DataBaseModel : IDataBase, INotifyPropertyChanged
    {

        string dbTitle = "";
        List<string> tables = new List<string>();
        public DataBaseModel(string dbTitle)
        {
            this.dbTitle = dbTitle;
            ParseTables();
        }

        public string DbTitle
        {
            get => dbTitle;
        }

        public List<string> Tables
        {
            get => tables;
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

        public bool CreateTable(TableModel table)
        {
            try
            {
                //TODO: запрос к БД на добавление таблицы
                tables.Add(table.TableTitle);
                OnPropertyChanged("Tables");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ClearDb()
        { 
            try
            {
                //TODO: запрос к БД на удаление всех таблиц
                tables.Clear();
                OnPropertyChanged("Tables");
                return true;
            }
            catch 
            { 
                return false; 
            }
        }

        public bool ParseTables()
        {
            try
            {
                //TODO: запрос к БД на парсинг заголовков таблиц
                for(int i = 0; i < 10; ++i)
                {
                    tables.Add($"table{i}");
                }
                OnPropertyChanged("Tables");
                return true;
            }
            catch 
            { 
                return false; 
            }
            
        }

        public bool RemoveTableByTitle(string tableTitle)
        {
            
            try
            {
                //TODO: запрос к БД на удаление таблицы
                tables.Remove(tableTitle);
                OnPropertyChanged("Tables");
                return true;
            }
            catch 
            { 
                return false; 
            }
        }

        public bool ClearTableByTitle(string tableTitle)
        {
            throw new NotImplementedException();
        }
    }
}
