using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Models.OrderDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;

namespace App.Service.Services.Implementations
{
    public class OrderService : ServiceBase, IOrderService
    {
        public OrderService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<string> CreateOrder(AddOrderDto orderDto)
        {
            var orderCode = await CreateOrderCode();
            var order = new OrderEntity
            {
                UserId = orderDto.UserId,
                Address = orderDto.Address,
                OrderCode = orderCode
            };
            order = await _repositoryManager.OrderRepository.CreateOrderAsync(order);
            var cartItems = await _repositoryManager.CartItemRepository.GetCartItemsByUserIdAsync(orderDto.UserId);
            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItemEntity
                {
                    OrderId = order.OrderId,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.Price
                };
                await _repositoryManager.OrderItemRepository.AddAsync(orderItem);
            }
            await _repositoryManager.OrderItemRepository.SaveAsync();
            return order.OrderCode;
        }

        public async Task<OrderDetailsDto> GetOrderDetailsAsync(string orderCode)
        {
            var orderEntity = await _repositoryManager.OrderRepository.GetOrderByOrderCodeIdAsync(orderCode);
            return _mapper.Map<OrderDetailsDto>(orderEntity);
        }

        public async Task<IEnumerable<MyOrderDto>>? GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _repositoryManager.OrderRepository.GetAllOrdersByUserIdAsync(userId);
            if (orders is null)
            {
                return null;
            }
            return _mapper.Map<IEnumerable<MyOrderDto>>(orders);
        }

        private async Task<string> CreateOrderCode()
        {
            string orderCode = Guid.NewGuid().ToString("n")[..16].ToUpperInvariant();
            while (await _repositoryManager.OrderRepository.AnyAsync(o => o.OrderCode == orderCode))
            {
                orderCode = Guid.NewGuid().ToString("n")[..16].ToUpperInvariant();
            }
            return orderCode;
        }
    }
}
