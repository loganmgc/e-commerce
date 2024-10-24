using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;

namespace App.Data.Repositories.Implenemtations
{
    public class CategoryRepository : RepositoryBase<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
