using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;

namespace App.Data.Repositories.Implenemtations
{
    public class OrderItemRepository : RepositoryBase<OrderItemEntity>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
