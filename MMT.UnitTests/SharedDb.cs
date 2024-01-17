
using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MMT.Models.DB;

namespace SharedDb
{

    public class TestDbContext : IDisposable
    {

        public TestDbContext()
        {
            Connection = new System.Data.SqlClient.SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;ConnectRetryCount=0");

            Connection.Open();
        }

        public DbConnection Connection { get; }

        public IMMTContext CreateContext()
        {
            return new MMTContext(new DbContextOptionsBuilder<MMTContext>().UseSqlServer(Connection).Options);
        }


        public void Dispose() => Connection.Dispose();
    }

}