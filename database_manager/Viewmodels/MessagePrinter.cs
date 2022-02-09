using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace database_manager.Viewmodels
{
    internal static class MessageDisplay
    {
        public static void DisplayException(Exception ex)
        {
            MessageBox.Show(ex.Message.ToString(), "Exception!");
        }
        public static void DisplayMessage(string message)
        {
            MessageBox.Show(message, "Message");
        }
    }
}
