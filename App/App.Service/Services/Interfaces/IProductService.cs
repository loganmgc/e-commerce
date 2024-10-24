using App.Service.Models.ProductDTOs;

namespace App.Service.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<GetProductDto>> GetAllProductsAsync();
        Task<IEnumerable<GetProductDto>> GetAllEnableProductsAsync();
        Task<IEnumerable<GetProductDto>> GetAllNotEnableProductsAsync();
        Task<(GetProductDto? product, string? error)> GetProductByIdAsync(int id);
        Task<IEnumerable<GetProductDto>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<GetProductDto>> GetProductsBySellerAsyınc(int sellerId);
        Task AddProductAsync(AddProductDto productDto);
        Task<bool> UpdateAsync(int id, UpdateProductDto productDto);
        Task<(bool isDeleted, string message)> DeleteProductAsync(int id);
    }
}
