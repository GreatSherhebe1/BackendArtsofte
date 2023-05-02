using Backend.Models;
using Backend.Services.Repositories;

namespace Backend.Schema.Mutation;

public class Mutation
{
    private readonly OrderRepository _ordersRepository;
    private readonly ProductRepository _prductsRepository;
    private readonly UserRepository _usersRepository;

    public Mutation(OrderRepository ordersRepository,
        ProductRepository productsRepository,
        UserRepository usersRepository)
    {
        _ordersRepository = ordersRepository;
        _prductsRepository = productsRepository;
        _usersRepository = usersRepository;
    }

    public async Task<Order> CreateOrder(OrderInputType orderInput)
    {
        var newOrder = new Order()
        {
            Cost = orderInput.Cost,
            Address = orderInput.Address,
            Createdate = orderInput.Createdate,
            Preparationdate = orderInput.Preparationdate,
            Completingdate = orderInput.Completingdate,
            Promocode = orderInput.Promocode,
            Userid = orderInput.Userid
        };

        await _ordersRepository.CreateOrderAsync(newOrder);
        return newOrder;
    }

    public async Task<Order> UpdateOrder(long id, OrderInputType orderInput)
    {
        var updateOrder = new Order()
        {
            Orderid = id,
            Cost = orderInput.Cost,
            Address = orderInput.Address,
            Createdate = orderInput.Createdate,
            Preparationdate = orderInput.Preparationdate,
            Completingdate = orderInput.Completingdate,
            Promocode = orderInput.Promocode,
            Userid = orderInput.Userid
        };

        await _ordersRepository.UpdateOrderAsync(updateOrder);
        return updateOrder;
    }

    public async Task<bool> DeleteOrderAsync(long id)
    {
        return await _ordersRepository.DeleteOrderAsync(id);
    }

    public async Task<Product> CreateProductAsync(ProductInputType productInput)
    {
        var newProduct = new Product()
        {
            Name = productInput.Name,
            Description = productInput.Description,
            Picture = productInput.Picture,
            Price = productInput.Price,
            Category = productInput.Category,
            Weight = productInput.Weight,
            Calories = productInput.Calories,
        };

        await _prductsRepository.CreateProductAsync(newProduct);
        return newProduct;
    }

    public async Task<Product> UpdateProductAsync(long id, ProductInputType productInput)
    {
        var updateProduct = new Product()
        {
            Name = productInput.Name,
            Description = productInput.Description,
            Picture = productInput.Picture,
            Price = productInput.Price,
            Category = productInput.Category,
            Weight = productInput.Weight,
            Calories = productInput.Calories,
        };

        await _prductsRepository.CreateProductAsync(updateProduct);
        return updateProduct;
    }

    public async Task<bool> DeleteProductAync(long id)
    {
        return await _prductsRepository.DeleteProductAsync(id);
    }

    public async Task<User> CreateUserAsync(UserInputType userInput)
    {
        var newUser = new User()
        {
            Name = userInput.Name,
            Address = userInput.Address,
            Phone = userInput.Phone,
            Birth = userInput.Birth,
            Email = userInput.Email,
            Gamepoints = 0
        };

        await _usersRepository.CreateUserAsync(newUser);
        return newUser;
    }

    public async Task<User> UpdateUserAsync(long id, UserInputType userInput)
    {
        var updateUser = new User()
        {
            Name = userInput.Name,
            Address = userInput.Address,
            Phone = userInput.Phone,
            Birth = userInput.Birth,
            Email = userInput.Email,
            Gamepoints = userInput.Gamepoints
        };

        await _usersRepository.UpdateUserAsync(updateUser);
        return updateUser;
    }

    public async Task<bool> DeleteUserAsync(long id)
    {
        return await _usersRepository.DeleteUserAsync(id);
    }
}