using Backend.Models;
using Backend.Services.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory<PostgresContext> _dbcontextFactory;

        public ProductRepository(IDbContextFactory<PostgresContext> dbcontextFactory)
        {
            _dbcontextFactory = dbcontextFactory;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _dbcontextFactory.CreateDbContext().Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(long productid)
        {
            return await _dbcontextFactory.CreateDbContext().Products.FirstOrDefaultAsync(p => p.Productid == productid);
        }

        public async Task CreateProductAsync(Product product)
        {
            using (var context = _dbcontextFactory.CreateDbContext())
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();

                return;
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            using (var context = _dbcontextFactory.CreateDbContext())
            {
                context.Products.Update(product);
                await context.SaveChangesAsync();

                return;
            }
        }

        public async Task<bool> DeleteProductAsync(long productid)
        {
            using (var context = _dbcontextFactory.CreateDbContext())
            {
                var product = new Product()
                {
                    Productid = productid
                };
                context.Products.Remove(product);
                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}
