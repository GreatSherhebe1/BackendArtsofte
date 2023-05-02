using Backend.Models;

namespace Backend.Services.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(long orderid);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(long userid);
    }
}
