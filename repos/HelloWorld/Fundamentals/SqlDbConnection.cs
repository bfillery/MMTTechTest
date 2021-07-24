using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Fundamentals
{
    public class SqlDbConnection : DbConnection
    {
        private SqlConnection cnn;


        public SqlDbConnection(string connectionString) 
            : base(connectionString)
        {
            cnn = new SqlConnection(base.ConnectionString);
        }

        public override bool Close()
        {
            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();

            return true;
        }

        public override bool Open()
        {
            //using (SqlConnection cnn = new SqlConnection(base.ConnectionString))
            //{
            
            bool ret;

            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open");
                ret = true;
                //cnn.Close();
            }
            catch (Exception ex)
            {
                ret = false;
                Console.WriteLine($"Cannot open connection : {ex.Message}");
            }

            return ret;
        }
    }
}
