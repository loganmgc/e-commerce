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

        public async Task<GetProductDto> GetProductByIdAsync(int id)
        {
            var product = await _repositoryManager.ProductRepository.GetProductByIdAsync(id);
            if (product is null)
            {
                return null;
            }
            var result = new GetProductDto()
            {
                ProductId = product.ProductId,
                SellerName = $"{product.Seller.FirstName} {product.Seller.LastName}",
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                Name = product.Name,
                Price = product.Price,
                Details = product.Details,
                StockAmount = product.StockAmount,
                DiscountPercentage = product.Discount == null ? null : product.Discount.DiscountRate,
                ImageUrls = product.ProductImages.Select(i => i.Url).ToArray()
            };
            return (result);
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
                DiscountId = productDto.DiscountId,
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
            existingProduct.CategoryId = productDto.CategoryId;
            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;
            existingProduct.Details = productDto.Details;
            existingProduct.StockAmount = productDto.StockAmount;
            existingProduct.DiscountId = productDto.DiscountId;
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

        public async Task<IEnumerable<ProductListingDto>> GetFeaturedProductsAsync()
        {
            var product = await _repositoryManager.ProductRepository.GetAllProductsAsync();
            var featuredProducts = product.Select(p => new ProductListingDto
            {
                Id = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Category.Name,
                DiscountPercentage = p.Discount == null ? null : p.Discount.DiscountRate,
                ImageUrl = p.ProductImages.Count != 0 ? p.ProductImages.First().Url : null
            }).ToList();
            return featuredProducts;
        }

        public async Task<IEnumerable<ProductListingDto>> GetFilteredProductsAsync(int count, string filterType)
        {
            var query = await _repositoryManager.ProductRepository.GetAllProductsAsync();
            query = filterType switch
            {
                "TopRated" => query.OrderByDescending(p => p.ProductComments.Any() ? p.ProductComments.Average(c => c.StarCount) : 0),
                "MostCommented" => query.OrderByDescending(p => p.ProductComments.Any() ? p.ProductComments?.Count : 0),
                "Latest" => query.OrderByDescending(p => p.CreatedAt),
                _ => query
            };
            var product = query.Take(count)
                .Select(p => new ProductListingDto
                {
                    Id = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    DiscountPercentage = p.Discount == null ? null : p.Discount.DiscountRate,
                    ImageUrl = p.ProductImages.Count != 0 ? p.ProductImages.First().Url : null
                }).ToList();
            return product;
        }
    }
}
