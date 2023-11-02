using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_stuff
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AdventureWorksEntities();

            var products = context.Products.Where(p=>p.Name.Contains ("Chainring"));



            foreach (var product in products)
                Console.WriteLine(product.Name);
        }
    }
}
