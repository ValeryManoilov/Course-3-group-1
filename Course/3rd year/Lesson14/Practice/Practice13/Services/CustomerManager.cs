using Microsoft.EntityFrameworkCore;
using Practice13.Context;
using Practice13.Interfaces;
using Practice13.Models;

namespace Practice13.Services
{
    public class CustomerManager : ICustomerManager
    {
        private readonly DeliveryAppContext _data;
        public CustomerManager(DeliveryAppContext data)
        {
            _data = data;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _data.Customers.Include(c => c.Orders).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(long customerId)
        {
            var customer = await _data.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            return customer;
        }

        public async Task<Customer> AddCustomer(Customer newCustomer)
        {
            var addingCustomer = await GetCustomerById(newCustomer.Id);
            if (addingCustomer == null)
            {
                await _data.Customers.AddAsync(newCustomer);
                _data.SaveChanges();
            }
            return newCustomer;
        }

        public async Task<Customer> DeleteCustomer(long customerId)
        {
            var deletingCustomer = await GetCustomerById(customerId);
            if (deletingCustomer != null)
            {
                _data.Remove(deletingCustomer);
                _data.SaveChanges();
            }
            return deletingCustomer;
        }
    }
}
