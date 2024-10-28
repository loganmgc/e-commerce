using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Repositories.Implenemtations
{
    public class CartItemRepository : RepositoryBase<CartItemEntity>, ICartItemRepository
    {
        public CartItemRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<CartItemEntity>> GetCartItemsByUserIdAsync(int userId)
        {
            return await _dbContext.CartItems
                .Where(c => c.UserId == userId)
                .Include(p => p.Product)
                .ThenInclude(p => p.ProductImages)
                .ToListAsync();
        }
    }
}
