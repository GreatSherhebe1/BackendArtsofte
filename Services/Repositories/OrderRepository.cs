using Backend.Models;
using Backend.Services.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContextFactory<PostgresContext> _dbcontextFactory;

        public OrderRepository(IDbContextFactory<PostgresContext> dbcontextFactory)
        {
            _dbcontextFactory = dbcontextFactory;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _dbcontextFactory.CreateDbContext().Orders.ToListAsync();
        }

        public async Task<Order> GetOrderAsync(long orderid)
        {
            return await _dbcontextFactory.CreateDbContext().Orders.FirstOrDefaultAsync(o => o.Orderid == orderid);
        }

        public async Task CreateOrderAsync(Order order)
        {
            using(var context = _dbcontextFactory.CreateDbContext())
            {
                context.Orders.Add(order);
                await context.SaveChangesAsync();

                return;
            }
        }

        public async Task UpdateOrderAsync(Order order)
        {
            using(var context = _dbcontextFactory.CreateDbContext())
            {
                context.Orders.Update(order);
                await context.SaveChangesAsync();

                return;
            }
        }

        public async Task<bool> DeleteOrderAsync(long orderid)
        {
            using(var context = _dbcontextFactory.CreateDbContext())
            {
                var order = new Order()
                {
                    Orderid = orderid
                };
                context.Orders.Remove(order);
                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}
