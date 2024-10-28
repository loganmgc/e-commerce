using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Repositories.Implenemtations
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            return await _dbContext.Users
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<UserEntity?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users
                .Include(u => u.Role)
                .SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserEntity?> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users
                .Include(u => u.Role)
                .SingleOrDefaultAsync(u => u.UserId == id);
        }
    }
}
