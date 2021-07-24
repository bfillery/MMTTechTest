using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Fundamentals
{
    public class DBMigrator
    {
        private readonly Logger logger;

        public DBMigrator(Logger logger)
        {
            this.logger = logger;
        }

        public void Migrate()
        {
            logger.Log("We are migrating...");
        }
    }
}
