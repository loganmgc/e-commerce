using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Repositories.Implenemtations
{
    public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ProductEntity>> GetAllNotEnableProductsAsync()
        {
            return await _dbContext.Products
                .Where(p => p.Enabled == false)
                .Include(c => c.Category)
                .Include(p => p.ProductImages)
                .Include(d => d.Discount)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            return await _dbContext.Products
                .Where (p => p.Enabled == true)
                .Include(c => c.Category)
                .Include(p => p.ProductImages)
                .Include(d => d.Discount)
                .Include(pc => pc.ProductComments)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsWithCategoriesAsync()
        {
            return await _dbContext.Products
                .Where(p => p.Enabled == true)
                .Include(c => c.Category)
                .Include(c => c.ProductImages)
                .ToListAsync();
        }


        public async Task<ProductEntity?> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products
                .Include(c => c.Category)
                .Include(u => u.Seller)
                .Include(p => p.ProductImages)
                .Include(d => d.Discount)
                .SingleOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbContext.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(c => c.Category)
                .Include(u => u.Seller)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsBySellerAsync(int sellerId)
        {
            return await _dbContext.Products
                .Include(c => c.Category)
                .Include(p => p.ProductImages)
                .Include(d => d.Discount)
                .ToListAsync();
        }
        
    }
}
