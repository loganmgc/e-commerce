using App.Data.Data.Entities;

namespace App.Data.Repositories.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<OrderEntity>
    {
        Task<OrderEntity> CreateOrderAsync(OrderEntity order);
        Task<IEnumerable<OrderEntity>>? GetAllOrdersByUserIdAsync(int userId);
        Task<OrderEntity?> GetOrderByOrderCodeIdAsync(string orderCode);
    }
}
