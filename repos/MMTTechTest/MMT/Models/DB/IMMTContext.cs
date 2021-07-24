using Microsoft.EntityFrameworkCore;

namespace MMT.Models.DB
{
    public interface IMMTContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Product> Products { get; set; }
    }
}
