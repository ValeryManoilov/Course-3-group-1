using Practice13.Models;

namespace Practice13.Interfaces
{
    public interface IOrderManager
    {
        public Task<List<Order>> GetOrders();
        public Task<Order> GetOrderById(long orderId);
        public Task<Order> AddOrder(Order newOrder);
        public Task<Order> DeleteOrder(long orderId);
    }
}
