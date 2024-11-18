using Practice13.Models;

namespace Practice13.Interfaces
{
    public interface ICustomerManager
    {
        public Task<List<Customer>> GetCustomers();
        public Task<Customer> GetCustomerById(long customerId);
        public Task<Customer> AddCustomer(Customer customer);
        public Task<Customer> DeleteCustomer(long customerId);
    }
}
