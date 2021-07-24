using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Fundamentals
{
    public class DbCommand
    {
        private readonly DbConnection Connection;

        private readonly string Instruction;


        public DbCommand(DbConnection connection, string instruction)
        {
            if (connection == null)
                throw new ArgumentNullException("DbConnection", "DbConnection is required");

            if (instruction == null)
                throw new ArgumentNullException("DbConnection", "DbConnection is required");

            Connection = connection;
            Instruction = instruction;

        }

        public  bool Execute()
        {
            bool ret;

            try
            {
                if (!Connection.Open())
                    return false;

                Console.WriteLine(Instruction);
                
                if (!Connection.Close())
                    return false;

                ret = true;

            }
            catch
            {
                throw new InvalidOperationException("Unable to execute task");
            }
                
            return ret;
        }
    }
}
