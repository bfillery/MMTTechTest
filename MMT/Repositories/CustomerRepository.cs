using Microsoft.Extensions.Configuration;
using MMT.Models;
using MMT.Models.DB;
using MMT.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MMT.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly IConfiguration _configuration;
		private bool disposedValue;

		public CustomerRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}


		public async Task<CustomerDTO> GetCustomer(string Email)
		{
			CustomerDTO customer = new();
			using (var httpClient = new HttpClient())
			{
				//TODO: move this to appsettings.json specific to the environment

				using var response = await httpClient.GetAsync(GetCustomerQueryString(Email));

				string apiResponse = await response.Content.ReadAsStringAsync();

				customer = JsonConvert.DeserializeObject<CustomerDTO>(apiResponse);
			}
			return customer;

		}

		public string GetDeliveryAddress(CustomerDTO customer)
		{

			//TODO: maybe an extension method..

			//TODO: could be static

			var address = string.Concat(
					(customer.HouseNumber  == null ? string.Empty : customer.HouseNumber + " "),
					(customer.Street == null ? string.Empty : customer.Street + ", "),
					(customer.Town == null ? string.Empty : customer.Town + ", "),
					(customer.Postcode == null ? string.Empty : customer.Postcode)
				);

			//remove trailing space/ comma if found
			address = address.Trim();
			if (address.Substring(address.Length - 1) == ",")
				address = address.Substring(address.Length - 1);

			return address;
		}


		private string GetCustomerQueryString(string eMail)
		{
			return _configuration["CustomerApiUrl"] + "?code=" + _configuration["CustomerApiCode"] + "&email=" + (eMail ?? string.Empty);
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
