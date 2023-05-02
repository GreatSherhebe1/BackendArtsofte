using Backend.Models;

namespace Backend.Services.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(long orderid);
        Task CreateProductAsync(Product order);
        Task UpdateProductAsync(Product order);
        Task<bool> DeleteProductAsync(long productid);
    }
}
