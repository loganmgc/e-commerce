using App.Service.Models.CartItemDTOs;

namespace App.Service.Services.Interfaces
{
    public interface ICartItemService
    {
        Task AddProductToCartAsync(AddCartItemDto product);
        Task<IEnumerable<GetCartItemDto>> GetCartItemsByUserIdAsync(int userId);
        Task<bool> DeleteProductFromCartAsync(int cartItemId);
        Task<GetCartItemDto> GetCartItemByIdAsync(int cartItemId);
        Task<GetCartItemDto> UpdateCartItemAsync(UpdateCartItemDto cartItemDto);
    }
}
