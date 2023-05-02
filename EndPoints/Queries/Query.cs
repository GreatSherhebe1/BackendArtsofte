using Backend.Models;
using Backend.Services.Repositories;
using System.Security.Claims;

namespace Backend.Schema.Queries;

public class Query
{
    private readonly OrderRepository _orderRepository;
    private readonly ProductRepository _productRepository;
    private readonly UserRepository _userRepository;

    public Query(OrderRepository orderRepository,
        ProductRepository productRepository,
        UserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public  async Task<List<Order>> GetOrdersAsync()
    {
        return await _orderRepository.GetAllOrdersAsync();
    }

    public async Task<Order> GetOrderAsync(long id)
    {
        return await _orderRepository.GetOrderAsync(id);
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<User> GetUserAsync(long id)
    {
        return await _userRepository.GetUserAsync(id);
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _productRepository.GetAllProductsAsync();
    }

    public async Task<Product> GetProductAsync(long id)
    {
        return await _productRepository.GetProductAsync(id);
    }
}