using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Repositories.Implenemtations
{
    public class BlogRepository : RepositoryBase<BlogEntity>, IBlogRepository
    {
        public BlogRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<BlogEntity>> GetAllBlogsAsync()
        {
            return await _dbContext.Blogs
                .Include(b => b.BlogComments)
                .ToListAsync();
        }
    }
}
