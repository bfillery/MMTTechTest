using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MMT.Models;
using MMT.Models.DB;
using MMT.Repositories;
using System;
using System.Threading.Tasks;

namespace MMT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMMTContext _context;
        private readonly IConfiguration _configuration;
        public OrderController(IConfiguration configuration, IMMTContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        //TODO: add swagger doc detail
        /// <summary>
        /// Returns the latest order for a given customer
        /// </summary>

        [HttpPost]
        [Route("{user},{customerId}")]
        public async Task<ActionResult<CustomerOrder>> GetLatestOrder(string user, string customerId)
        {

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(customerId))
                throw new ArgumentException("Both user and customerId are required");


            using CustomerRepository custRepo = new(_configuration);
            CustomerDTO cust = await custRepo.GetCustomer(user);
            if (cust == null)
                return NotFound(); //404

            if (cust.CustomerId != customerId)
                throw new ArgumentException("Supplied customerId does not match the stored value for the given user");

            CustomerOrder customerOrder = new();
            customerOrder.Customer = cust;

            using OrderRepository ordRepo = new(_context);
            customerOrder.Order = ordRepo.GetLatestOrder(customerId);

            //populate the address if an order exists
            if(customerOrder.Order!=null)
                customerOrder.Order.DeliveryAddress = custRepo.GetDeliveryAddress(cust);

            return customerOrder;

        }

    }
}
