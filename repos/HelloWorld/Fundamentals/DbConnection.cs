using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Fundamentals
{
    public abstract class DbConnection
    {
        public string ConnectionString { get; private set; }

        public TimeSpan Timeout { get; set; }


        public DbConnection(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString", "Connection string is required");

            ConnectionString = connectionString;
        }


        public abstract bool Open();

        public abstract bool Close();
    }
}
