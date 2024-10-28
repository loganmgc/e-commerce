using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Repositories.Implenemtations
{
    public class ProductCommentRepository : RepositoryBase<ProductCommentEntity>, IProductCommentRepository
    {
        public ProductCommentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ProductCommentEntity?>> GetAllCommentsByProductIdAsync(int productId)
        {
            return await _dbContext.ProductComments
                .Include(u => u.User)
                .Include(p => p.Product)
                .Where(c => c.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductCommentEntity?>> GetAllCommentsByUserIdAsync(int userId)
        {
            return await _dbContext.ProductComments
                .Include(u => u.User)
                .Include(p => p.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductCommentEntity?>> GetAllUnapprovedCommentsAsync()
        {
            return await _dbContext.ProductComments
                .Where(c => c.IsConfirmed == false)
                .Include(p => p.Product)
                .Include(u => u.User)
                .ToListAsync();
        }
    }
}
