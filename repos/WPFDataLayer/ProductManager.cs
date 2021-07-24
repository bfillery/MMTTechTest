using System;
using System.Collections.Generic;
using System.Text;

namespace WPFDataLayer
{
    public class ProductManager
    {

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    ProductID = 706,
                    Name = "HL Road frame - red, 58",
                    ProductNumber = "FR-R92R-58",
                    Color = "Red",
                    StandardCost = 1059.31M,
                    ListPrice = 1431.5M,
                    Size = "58",
                    Weight = 1016.04M,
                    SellStartDate = Convert.ToDateTime("Jun 1 1998 12:00AM"),
                    SellEndDate = Convert.ToDateTime("Jun 1 1998 12:00AM"),
                    DiscontinuedDate = null
                },

                new Product
                {
                    ProductID = 707,
                    Name = "Sport helmet, Red",
                    ProductNumber = "HL-U509-R",
                    Color = "Red",
                    StandardCost = 13.08M,
                    ListPrice = 34.99M,
                    Size = string.Empty,
                    Weight = null,
                    SellStartDate = Convert.ToDateTime("Jul 1 2001 12:00AM"),
                    SellEndDate = null,
                    DiscontinuedDate = null
                },

                new Product
                {
                    ProductID = 708,
                    Name = "Sport helmet, Black",
                    ProductNumber = "HL-U509",
                    Color = "Black",
                    StandardCost = 13.09M,
                    ListPrice = 34.99M,
                    Size = string.Empty,
                    Weight = null,
                    SellStartDate = Convert.ToDateTime("Jul 1 2001 12:00AM"),
                    SellEndDate = null,
                    DiscontinuedDate = null
                }
            };
        }
    }
}
