using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Models.CartItemDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;

namespace App.Service.Services.Implementations
{
    public class CartItemService : ServiceBase, ICartItemService
    {
        public CartItemService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task AddProductToCartAsync(AddCartItemDto product)
        {
            var existingCartItem = await _repositoryManager.CartItemRepository.FindAsync(c => c.UserId == product.UserId && c.ProductId == product.ProductId);
            if (existingCartItem is not null)
            {
                existingCartItem.Quantity += product.Quantity;
            }
            else
            {
                var cartItem = _mapper.Map<CartItemEntity>(product);
                await _repositoryManager.CartItemRepository.AddAsync(cartItem);
            }
            await _repositoryManager.CartItemRepository.SaveAsync();
        }

        public async Task<bool> DeleteProductFromCartAsync(int cartItemId)
        {
            var existingCartItem = await _repositoryManager.CartItemRepository.GetByIdAsync(cartItemId);
            if (existingCartItem is null)
            {
                return false;
            }
            _repositoryManager.CartItemRepository.Delete(existingCartItem);
            await _repositoryManager.CartItemRepository.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<GetCartItemDto>> GetCartItemsByUserIdAsync(int userId)
        {
            var cartItems = await _repositoryManager.CartItemRepository.GetCartItemsByUserIdAsync(userId);
            if (cartItems is null)
            {
                return null;
            }
            return _mapper.Map<IEnumerable<GetCartItemDto>>(cartItems);
        }
    }
}
