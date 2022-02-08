using System;
using System.Windows.Controls;

namespace database_manager.UserControls
{
    public partial class TablesListUserControl : UserControl
    {
        public TablesListUserControl()
        {
            InitializeComponent();
        }
        public string SelectedTitle
        {
            get 
            {
                if (this.listboxTables.SelectedItem.ToString() == null)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    return this.listboxTables.SelectedItem.ToString();
                }
            }
        }
    }
}
