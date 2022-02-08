using database_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_manager.Viewmodels
{
    internal class MainViewModel
    {
        DataBaseModel dbModel;
        public MainViewModel(DataBaseModel dbModel)
        {
            this.dbModel = dbModel;
        }
        public List<string> Tables
        {
            get => dbModel.Tables;
        }
    }
    
}
