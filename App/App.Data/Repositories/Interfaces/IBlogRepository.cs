using App.Data.Data.Entities;
using App.Data.Entities;

namespace App.Data.Repositories.Interfaces
{
    public interface IBlogRepository : IRepositoryBase<BlogEntity>
    {
        Task<IEnumerable<BlogEntity>> GetAllBlogsAsync();
    }
}
