using App.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Helpers;
using App.Service.Models.ProductDTOs;
using App.Service.Services.Interfaces;

namespace App.Service.Services.Implementations
{
    public class ProductService : IProductService
    {
        private IRepositoryManager _repositoryManager;
        private readonly ProductHelper _productHelper;

        public ProductService(IRepositoryManager repositoryManager, ProductHelper productHelper)
        {
            _repositoryManager = repositoryManager;
            _productHelper = productHelper;
        }

        public async Task<IEnumerable<GetProductDto>> GetAllEnableProductsAsync()
        {
            var products = await _repositoryManager.ProductRepository.GetAllEnableProductsAsync();
            return _productHelper.ProductListing(products);
        }

        public async Task<IEnumerable<GetProductDto>> GetAllNotEnableProductsAsync()
        {
            var products = await _repositoryManager.ProductRepository.GetAllNotEnableProductsAsync();
            return _productHelper.ProductListing(products);
        }

        public async Task<IEnumerable<GetProductDto>> GetAllProductsAsync()
        {
            var products = await _repositoryManager.ProductRepository.GetAllProductsAsync();
            return _productHelper.ProductListing(products);
        }

        public async Task<(GetProductDto? product, string? error)> GetProductByIdAsync(int id)
        {
            var product = await _repositoryManager.ProductRepository.GetProductByIdAsync(id);
            if (product is null)
            {
                return (null, "Product not found");
            }
            var result = new GetProductDto()
            {
                ProductId = product.ProductId,
                SellerId = product.SellerId,
                SellerName = $"{product.Seller.FirstName} {product.Seller.LastName}",
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                Name = product.Name,
                Price = product.Price,
                Details = product.Details,
                StockAmount = product.StockAmount,
                CreatedAt = product.CreatedAt,
            };
            return (result, null);
        }

        public async Task<IEnumerable<GetProductDto>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await _repositoryManager.ProductRepository.GetProductsByCategoryAsync(categoryId);
            return _productHelper.ProductListing(products);
        }

        public async Task<IEnumerable<GetProductDto>> GetProductsBySellerAsyınc(int sellerId)
        {
            var products = await _repositoryManager.ProductRepository.GetProductsBySellerAsync(sellerId);
            return _productHelper.ProductListing(products);
        }

        public async Task AddProductAsync(AddProductDto productDto)
        {
            var product = new ProductEntity()
            {
                SellerId = productDto.SellerId,
                CategoryId = productDto.CategoryId,
                Name = productDto.Name,
                Price = productDto.Price,
                Details = productDto.Details,
                StockAmount = productDto.StockAmount,
                Enabled = true
            };
            await _repositoryManager.ProductRepository.AddAsync(product);
            await _repositoryManager.ProductRepository.SaveAsync();
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto productDto)
        {
            var existingProduct = await _repositoryManager.ProductRepository.GetByIdAsync(id);
            if (existingProduct is null || existingProduct.ProductId != productDto.Id)
            {
                return false;
            }
            existingProduct.SellerId = id;
            existingProduct.CategoryId = productDto.CategoryId;
            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;
            existingProduct.Details = productDto.Details;
            existingProduct.StockAmount = productDto.StockAmount;
            _repositoryManager.ProductRepository.Update(existingProduct);
            await _repositoryManager.ProductRepository.SaveAsync();
            return true;
        }

        public async Task<(bool isDeleted, string message)> DeleteProductAsync(int id)
        {
            var existingProduct = await _repositoryManager.ProductRepository.GetByIdAsync(id);
            if (existingProduct is null)
            {
                return (false, "Product not found");
            }
            _repositoryManager.ProductRepository.Delete(existingProduct);
            await _repositoryManager.ProductRepository.SaveAsync();
            return (true, "Product successfuly deleted");
        }
    }
}
