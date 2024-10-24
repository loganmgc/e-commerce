using App.Data.Data.Entities;

namespace App.Data.Repositories.Interfaces
{
    public interface IProductCommentRepository : IRepositoryBase<ProductCommentEntity>
    {
        Task<IEnumerable<ProductCommentEntity?>> GetAllCommentsByUserIdAsync(int userId);
        Task<IEnumerable<ProductCommentEntity?>> GetAllCommentsByProductIdAsync(int productId);
    }
}
