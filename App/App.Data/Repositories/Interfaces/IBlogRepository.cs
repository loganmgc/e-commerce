using App.Data.Data.Entities;

namespace App.Data.Repositories.Interfaces
{
    public interface IBlogRepository : IRepositoryBase<BlogEntity>
    {
        Task<IEnumerable<BlogEntity>> GetAllBlogsAsync();
    }
}
