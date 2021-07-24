using MMT.Models;
using System;
using System.Threading.Tasks;

namespace MMT.Repositories.Interfaces
{
    public interface ICustomerRepository : IDisposable
    {
        public Task<CustomerDTO> GetCustomer(string Email);

        public string GetDeliveryAddress(CustomerDTO customer);
    }

}
