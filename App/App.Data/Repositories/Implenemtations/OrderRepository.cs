using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Repositories.Implenemtations
{
    public class OrderRepository : RepositoryBase<OrderEntity>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task<OrderEntity?> GetOrderByOrderCodeIdAsync(string orderCode)
        {
            return await _dbContext.Orders.Include(o => o.OrderItems).
                ThenInclude(o => o.Product).
                FirstOrDefaultAsync(o => o.OrderCode ==orderCode);
        }

        public async Task<OrderEntity> CreateOrderAsync(OrderEntity order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<OrderEntity>>? GetAllOrdersByUserIdAsync(int userId)
        {
            return await _dbContext.Orders.Where(o => o.UserId == userId).
                Include(o => o.OrderItems).
                ToListAsync();
        }
    }
}
