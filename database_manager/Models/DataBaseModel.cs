using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database_manager.Data;
using database_manager.Viewmodels;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Collections.ObjectModel;

namespace database_manager.Models
{
   /* interface IDataBase
    {
        string DbTitle { get; }
        List<string> Tables { get; }
        
        bool ParseTables();
        bool RemoveTableByTitle(string tableTitle);
        bool CreateTable(TableModel table);
        
        bool ClearDb();
        bool ClearTableByTitle(string tableTitle);
    }*/

    internal class DataBaseModel : INotifyPropertyChanged
    {
        bool connected = false;
        string dbTitle = "";
        string dataSource = "";
        ObservableCollection<string> tables = new ObservableCollection<string>();
        SqliteConnection connection;
        public DataBaseModel()
        {
            this.dbTitle = DBinfo.Title;
            this.dataSource = DBinfo.Source;
            Connect();
            ParseTables();
        }
        public bool Connected
        {
            get => connected;
        }
        public string DbTitle
        {
            get => dbTitle;
        }
        public void Connect()
        {
            try
            {
                if (File.Exists(dataSource) == false)
                {
                    MessageDisplay.DisplayMessage($"Not found file : {dataSource}");
                }
                else
                {
                    connection = new SqliteConnection($"Data Source={dataSource}");
                    connection.Open();
                    connected = true;
                }
            }
            catch (Exception ex)
            {
                MessageDisplay.DisplayException(ex);
            }   
        }
        public ObservableCollection<string> Tables
        {
            get => tables;
            set => tables = value;
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

        public void ParseTables()
        {
            if (connected)
            {
                try
                {
                    var command = connection.CreateCommand();
                    command.CommandText =
                    @$"
                        SELECT name FROM sqlite_master WHERE type='table'
                    ";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tables.Add(reader.GetString(0));
                        }
                        OnPropertyChanged("Tables");
                    }   
                }
                catch (Exception ex)
                {
                    MessageDisplay.DisplayException(ex);
                }
            }
            
        }
        public void RemoveTableByTitle(object tableTitle)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText =@$"DROP TABLE {tableTitle.ToString()}";
                var tablesRemoved = command.ExecuteNonQuery();
                if (tablesRemoved > 0)
                {
                    tables.Remove(tableTitle.ToString());
                    OnPropertyChanged("Tables");
                }
            }
            catch (Exception ex)
            {
                MessageDisplay.DisplayException(ex);
            }
        }
        public void CreateTable(object tableTitle)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = @$"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableTitle.ToString()}';";
                object selectedTable = command.ExecuteScalar();
                if (selectedTable == null)
                {
                    command.CommandText = @$"CREATE TABLE IF NOT EXISTS {tableTitle.ToString()} (ID INTEGER) ";
                    command.ExecuteNonQuery();
                    tables.Add(tableTitle.ToString());
                    OnPropertyChanged("Tables");
                }
            }
            catch (Exception ex)
            {
                MessageDisplay.DisplayException(ex);
            }
        }

        public List<string> ParseFieldsTitlesFromTable(string tableTitle)
        {
            List<string> titles = new List<string>();
            var command = connection.CreateCommand();
            command.CommandText = @$"SELECT name FROM pragma_table_info('{tableTitle}') ORDER BY cid";
            using(var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    titles.Add(reader.GetString(0));
                }
            }
            return titles;
        }
        public List<Item>ParseItemsFromTable(string tableTitle)
        {
            List<Item> items = new List<Item>();
            ParseFieldsTitlesFromTable(tableTitle);
            var command = connection.CreateCommand();
            command.CommandText = @$"SELECT ALL FROM {tableTitle} WHERE ";
            return items;

        }
    }
}
