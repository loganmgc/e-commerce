using App.Data.Entities;
using App.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Repositories.Implenemtations
{
    public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ProductEntity>> GetAllEnableProductsAsync()
        {
            var products = await _dbContext.Products
                .Include(c => c.Category)
                .Include(u => u.Seller)
                .Where(p => p.Enabled == true)
                .ToListAsync();
            return products ?? Enumerable.Empty<ProductEntity>();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllNotEnableProductsAsync()
        {
            return await _dbContext.Products
                .Include(c => c.Category)
                .Include(u => u.Seller)
                .Where(p => p.Enabled == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            return await _dbContext.Products
                .Include(c => c.Category)
                .Include(u => u.Seller)
                .ToListAsync();
        }

        public async Task<ProductEntity?> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products
                .Include(c => c.Category)
                .Include(u => u.Seller)
                .SingleOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbContext.Products
                .Include(c => c.Category)
                .Include(u => u.Seller)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsBySellerAsync(int sellerId)
        {
            return await _dbContext.Products
                .Include(c => c.Category)
                .Include(u => u.Seller)
                .Where(p => p.SellerId == sellerId)
                .ToListAsync();
        }
        
    }
}
