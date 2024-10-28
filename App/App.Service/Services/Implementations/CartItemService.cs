using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Models.CartItemDTOs;
using App.Service.Services.Interfaces;

namespace App.Service.Services.Implementations
{
    public class CartItemService : ICartItemService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CartItemService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
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
                var cartItem = new CartItemEntity
                {
                    UserId = product.UserId,
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                };
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
            return cartItems.Select(c => new GetCartItemDto
            {
                CartItemId = c.CartItemId,
                UserId = userId,
                ProductId = c.ProductId,
                ProductName = c.Product.Name,
                ProductPrice = c.Product.Price,
                ProductImage = c.Product.ProductImages.Count != 0 ? c.Product.ProductImages.First().Url : null,
                Quantity = c.Quantity,
            });
        }
    }
}
