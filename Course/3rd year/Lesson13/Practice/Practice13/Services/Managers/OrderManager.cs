using Microsoft.EntityFrameworkCore;
using Practice13.Services.Context;
using Practice13.Services.Interfaces;
using Practice13.Services.Models;

namespace Practice13.Services.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly DeliveryAppContext _data;
        public OrderManager(DeliveryAppContext data)
        {
            _data = data;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _data.Orders.Include(o => o.OrderProducts).ToListAsync();
        }

        public async Task<Order> GetOrderById(long orderId)
        {
            var needOrder = await _data.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            return needOrder;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _data.Orders.AddAsync(order);
            _data.SaveChanges();
            return order;
        }

        public async Task<Order> DeleteOrder(long orderId)
        {
            var deletingOrder = await GetOrderById(orderId);
            if (deletingOrder != null)
            {
                _data.Remove(deletingOrder);
            }
            return deletingOrder;
        }
    }
}
