using MMT.Models;
using MMT.Models.DB;
using System;

namespace MMT.Repositories.Interfaces
{
    public interface IOrderRepository : IDisposable
    {


        public OrderDTO GetLatestOrder(string CustomerID);

        public OrderDTO OrderToOrderDTO(Order order);


        public OrderItemDTO OrderItemToOrderItemDTO(OrderItem orderItem);

        public Product GetProductFromId(int id);

    }
}
