using Practice13.Services.Models;

namespace Practice13.Services.Interfaces
{
    public interface ICustomerManager
    {
        public Task<List<Customer>> GetCustomers();
        public Task<Customer> GetCustomerById(long customerId);
        public Task<Customer> AddCustomer(Customer customer);
        public Task<Customer> DeleteCustomer(long customerId);
    }
}
