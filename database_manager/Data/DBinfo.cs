using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_manager.Data
{
    internal static class DBinfo
    {
        static string title = "";
        static string source = @"C:\sample_db.db";
        static public string Title { get => title; }
        static public string Source { get => source; }
    }
}
