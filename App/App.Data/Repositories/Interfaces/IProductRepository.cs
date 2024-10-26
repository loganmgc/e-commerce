using App.Data.Entities;

namespace App.Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepositoryBase<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
        Task<IEnumerable<ProductEntity>> GetAllNotEnableProductsAsync();
        Task<ProductEntity?> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductEntity>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<ProductEntity>> GetProductsBySellerAsync(int sellerId);
        Task<IEnumerable<ProductEntity>> GetProductsWithCategoriesAsync();
    }
}
 