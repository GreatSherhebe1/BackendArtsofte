using Backend.Models;
using Backend.Services.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<PostgresContext> _dbcontextFactory;

        public UserRepository(IDbContextFactory<PostgresContext> dbcontextFactory)
        {
            _dbcontextFactory = dbcontextFactory;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbcontextFactory.CreateDbContext().Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(long userid)
        {
            return await _dbcontextFactory.CreateDbContext().Users.FirstOrDefaultAsync(p => p.Userid == userid);
        }

        public async Task CreateUserAsync(User user)
        {
            using (var context = _dbcontextFactory.CreateDbContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();

                return;
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            using (var context = _dbcontextFactory.CreateDbContext())
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();

                return;
            }
        }

        public async Task<bool> DeleteUserAsync(long userid)
        {
            using (var context = _dbcontextFactory.CreateDbContext())
            {
                var user = new User()
                {
                    Userid = userid
                };
                context.Users.Remove(user);
                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}
