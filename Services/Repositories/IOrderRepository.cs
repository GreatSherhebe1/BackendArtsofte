using Backend.Models;

namespace Backend.Services.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderAsync(long orderid);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(long orderid);
    }
}
