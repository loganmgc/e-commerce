using App.Data.Data.Entities;

namespace App.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        Task<UserEntity?> GetUserByEmailAsync(string email);
        Task<UserEntity?> GetUserByIdAsync(int id);
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        Task<UserEntity?> GetUserByVerificationCode(string verificationCode);
    }
}
