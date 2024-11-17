using App.Service.Models.OrderDTOs;

namespace App.Service.Services.Interfaces
{
    public interface IOrderService : IServiceBase
    {
        Task<string> CreateOrder(AddOrderDto orderDto);
        Task<OrderDetailsDto> GetOrderDetailsAsync(string orderCode);
        Task<IEnumerable<MyOrderDto>> GetOrdersByUserIdAsync(int userId);
    }
}
