using App.Data.Data.Entities;

namespace App.Data.Repositories.Interfaces
{
    public interface ICartItemRepository : IRepositoryBase<CartItemEntity>
    {
        Task<IEnumerable<CartItemEntity>> GetCartItemsByUserIdAsync(int userId);
    }
}
