using App.Service.Models.ProductDTOs;

namespace App.Service.Services.Interfaces
{
    public interface IProductService
    {
        Task<GetProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<GetProductsBySellerIdDto>> GetProductsBySellerIdAsync(int sellerId);
        Task AddProductAsync(AddProductDto productDto);
        Task<bool> UpdateAsync(int id, UpdateProductDto productDto);
        Task<(bool isDeleted, string message)> DeleteProductAsync(int id);
        Task<IEnumerable<ProductListingDto>> GetFeaturedProductsAsync();
        Task<IEnumerable<ProductListingDto>> GetFilteredProductsAsync(int count, string filterType);
    }
}
