using System;
using System.Collections.Generic;

namespace MMT.Models
{
    public class OrderDTO
    {
        public OrderDTO()
        {
            OrderItems = new();
        }


        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
