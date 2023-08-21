using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Settings
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public string ConnectionString { get; }

        public DatabaseConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
