using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using database_manager.Models;
using database_manager.Viewmodels;
using database_manager.Data;
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

            DataBaseModel dbModel = new DataBaseModel(DBinfo.Title);
            MainViewModel mainViewModel = new MainViewModel(dbModel);

            TableModel tableModel = new TableModel();
            TableViewModel tableViewModel = new TableViewModel(tableModel);

            this.TablesList.DataContext = mainViewModel;
            this.ItemsList.DataContext = tableViewModel;
            this.FieldsList.DataContext = tableViewModel;
        }
    }
}
