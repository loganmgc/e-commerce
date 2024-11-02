using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Models.CategoryDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;

namespace App.Service.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CategoryService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task AddCategoryAsync(AddCategoryDto categoryDto)
        {
            var category = _mapper.Map<CategoryEntity>(categoryDto);
            await _repositoryManager.CategoryRepository.AddAsync(category);
            await _repositoryManager.CategoryRepository.SaveAsync();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var existingCategory = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
            if (existingCategory is null)
            {
                return false;
            }
            _repositoryManager.CategoryRepository.Delete(existingCategory);
            await _repositoryManager.CategoryRepository.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<GetCategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _repositoryManager.CategoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetCategoryDto>>(categories);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesForSliderAsync()
        {
            var products = await _repositoryManager.ProductRepository.GetProductsWithCategoriesAsync();
            return products.GroupBy(p => p.CategoryId)
                .Select(g => _mapper.Map<CategoryDto>(g.First()))
                .ToList();
        }

        public async Task<GetCategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return null;
            }
            return _mapper.Map<GetCategoryDto>(category);
        }

        public async Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto)
        {
            var existingCategory = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
            if (existingCategory is null || existingCategory.CategoryId != categoryDto.CategoryId)
            {
                return false;
            }
            _mapper.Map(categoryDto, existingCategory);
            _repositoryManager.CategoryRepository.Update(existingCategory);
            await _repositoryManager.CategoryRepository.SaveAsync();
            return true;
        }
    }
}
