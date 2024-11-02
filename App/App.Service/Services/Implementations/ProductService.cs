using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Models.ProductDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;

namespace App.Service.Services.Implementations
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<GetProductDto> GetProductByIdAsync(int id)
        {
            var product = await _repositoryManager.ProductRepository.GetProductByIdAsync(id);
            if (product is null)
            {
                return null;
            }
            return _mapper.Map<GetProductDto>(product);
        }


        public async Task<IEnumerable<GetProductsBySellerIdDto>> GetProductsBySellerIdAsync(int sellerId)
        {
            var products = await _repositoryManager.ProductRepository.GetProductsBySellerAsync(sellerId);
            if (products is null)
            {
                return null;
            }
            return _mapper.Map<IEnumerable<GetProductsBySellerIdDto>>(products);
        }

        public async Task AddProductAsync(AddProductDto productDto)
        {
            var product = _mapper.Map<ProductEntity>(productDto);
            await _repositoryManager.ProductRepository.AddAsync(product);
            await _repositoryManager.ProductRepository.SaveAsync();
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto productDto)
        {
            var existingProduct = await _repositoryManager.ProductRepository.GetByIdAsync(id);
            if (existingProduct is null || existingProduct.ProductId != productDto.ProductId)
            {
                return false;
            }
            _mapper.Map(productDto, existingProduct);
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
            return _mapper.Map<IEnumerable<ProductListingDto>>(product);
        }

        public async Task<IEnumerable<ProductListingDto>> GetFilteredProductsAsync(int count, string filterType)
        {
            var query = await _repositoryManager.ProductRepository.GetAllProductsAsync();
            query = filterType switch
            {
                "TopRated" => query.OrderByDescending(p => p.ProductComments.Any() ? p.ProductComments.Average(c => c.StarCount) : 0),
                "Review" => query.OrderByDescending(p => p.ProductComments.Any() ? p.ProductComments?.Count : 0),
                "Latest" => query.OrderByDescending(p => p.CreatedAt),
                _ => query
            };
            return _mapper.Map<IEnumerable<ProductListingDto>>(query);
        }
    }
}
