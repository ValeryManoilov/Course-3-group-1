using Practice13.Services.Models;

namespace Practice13.Services.Interfaces
{
    public interface IOrderManager
    {
        public Task<List<Order>> GetOrders();
        public Task<Order> GetOrderById(long orderId);
        public Task<Order> AddOrder(Order order);
        public Task<Order> DeleteOrder(long orderId);
    }
}
