using MMT.Models.DB;
using MMT.Repositories;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;

namespace MMT.UnitTests
{
    public class Tests
    {
        private IMMTContext context;

        [SetUp]
        public void Setup()
        {
            context = new SharedDb.TestDbContext().CreateContext();
        }

        [Test]
        public void OrderToOrderDTO_NullOrder_ReturnsBlankOrderDTO()
        {
            //arrange
            var orderRepo = new OrderRepository(context);


            //act
            var result = orderRepo.OrderToOrderDTO(null);

            //asert
            ClassicAssert.IsTrue(result.OrderDate==System.DateTime.MinValue && result.OrderNumber==0 && result.OrderItems.Count==0);
        }


        [Test]
        public void OrderToOrderDTO_PopulatedOrder_ReturnsPopulatedOrderDTO()
        {
            //arrange
            var orderRepo = new OrderRepository(context);
            Order order = new()
            {
                ORDERID = 1,
                CUSTOMERID = 2,
                ORDERDATE = DateTime.Parse("01 Feb 2020"),
                DELIVERYEXPECTED = DateTime.Parse("10 Feb 2020"),
                CONTAINSGIFT = false,
                SHIPPINGMODE = "Courier",
                ORDERSOURCE = "Flyer"
            };

            //act
            var result = orderRepo.OrderToOrderDTO(order);

            //asert
            ClassicAssert.IsTrue(
                result.OrderDate == order.ORDERDATE && 
                result.OrderNumber == order.ORDERID 
                );
        }


        [Test]
        public void OrderItemToOrderItemDTO_NullOrder_ReturnsBlankOrderItemDTO()
        {
            //arrange
            var orderRepo = new OrderRepository(context);


            //act
            var result = orderRepo.OrderItemToOrderItemDTO(null);

            //asert
            ClassicAssert.IsTrue(result.PriceEach == 0 && result.Product == null && result.Quantity == 0);
        }


        [Test]
        public void OrderItemToOrderItemDTO_PopulatedOrderItem_ReturnsPopulatedOrderItemDTO()
        {
            //arrange
            var orderRepo = new OrderRepository(context);

            OrderItem orderItem = new()
            {
                ORDERITEMID = 1,
                ORDERID=2,
                //PRODUCTID=3,
                QUANTITY =4,
                PRICE=5.99M,
                RETURNABLE =true
            };

            //act
            var result = orderRepo.OrderItemToOrderItemDTO(orderItem);

            //asert
            ClassicAssert.IsTrue(
                result.PriceEach == orderItem.PRICE &&
                result.Quantity == orderItem.QUANTITY
                );
        }

        //public OrderDTO GetLatestOrder(string CustomerID);


        //public Product GetProductFromId(int id);
    }
}