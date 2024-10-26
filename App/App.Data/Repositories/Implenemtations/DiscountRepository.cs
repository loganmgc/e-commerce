using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;

namespace App.Data.Repositories.Implenemtations
{
    public class DiscountRepository : RepositoryBase<DiscountEntity>, IDiscountRepository
    {
        public DiscountRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
