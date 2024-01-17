

using Microsoft.EntityFrameworkCore;

namespace MMT.Models.DB
{
    public class MMTContext: DbContext, IMMTContext
    {

        public MMTContext(DbContextOptions<MMTContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
