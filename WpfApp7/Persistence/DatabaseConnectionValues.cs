using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp7.Persistence
{
    public static class DatabaseConnectionValues
    {
        public static readonly string Database_Name = "TimeTrackWpf.db";
        public static readonly string folder_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static readonly string database_path = System.IO.Path.Combine(folder_path, Database_Name);
    }
}
