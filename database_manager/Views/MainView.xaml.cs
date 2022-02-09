using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using database_manager.Models;
using database_manager.Viewmodels;
using System.Globalization;
using System.Threading;

namespace database_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            DataBaseModel dbModel = new DataBaseModel();
            TableModel tableModel = new TableModel(dbModel);
            DataBaseViewModel dbViewModel = new DataBaseViewModel(dbModel, tableModel);

            TableViewModel tableViewModel = new TableViewModel(tableModel);

            this.TablesList.DataContext = dbViewModel;
            this.ItemsList.DataContext = tableViewModel;
            this.FieldsList.DataContext = tableViewModel;
            this.textboxTableTitle.DataContext = tableViewModel;
        }
    }
}
