using MMT.Models;
using MMT.Models.DB;
using MMT.Repositories.Interfaces;
using System;
using System.Linq;

namespace MMT.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly IMMTContext _context;
        private bool disposedValue;

        public OrderRepository(IMMTContext context)
        {
            _context = context;
        }

        public OrderDTO GetLatestOrder(string CustomerID)
        {
            if (string.IsNullOrEmpty(CustomerID))
                throw new ArgumentNullException("Customer ID is required");

            return OrderToOrderDTO(GetLatestDbOrder(CustomerID));
        }


        private Order GetLatestDbOrder(string CustomerId)
        {
            return _context.Orders.Where(o => o.CUSTOMERID.Equals(CustomerId)).OrderByDescending(o=>o.ORDERDATE).FirstOrDefault();

        }


        public OrderDTO OrderToOrderDTO(Order order)
        {
            OrderDTO orderDTO = new();
            if(order!=null)
            {
                orderDTO.OrderNumber = order.ORDERID;
                orderDTO.OrderDate = order.ORDERDATE;
                //DeliveryAddress = order.  //later...

                foreach (OrderItem orderItem in _context.OrderItems.Where(o => o.ORDERID == order.ORDERID))
                    orderDTO.OrderItems.Add(OrderItemToOrderItemDTO(orderItem));
            };

            return orderDTO;
        }



        public OrderItemDTO OrderItemToOrderItemDTO(OrderItem orderItem)
        {
            OrderItemDTO orderItemDTO = new();
            if (orderItem != null)
            {
                orderItemDTO.Product = GetProductFromId(orderItem.PRODUCTID).PRODUCTNAME;
                orderItemDTO.Quantity = orderItem.QUANTITY;
                orderItemDTO.PriceEach = orderItem.PRICE;
            };

            return orderItemDTO;
        }



        public Product GetProductFromId(int id)
        {
            return _context.Products.Where(o => o.PRODUCTID == id).SingleOrDefault();
        }




        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CustomerRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }
}
