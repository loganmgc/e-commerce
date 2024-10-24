using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Models.CategoryDtos;
using App.Service.Services.Interfaces;

namespace App.Service.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task AddCategoryAsync(AddCategoryDto categoryDto)
        {
            var category = new CategoryEntity()
            {
                Name = categoryDto.Name,
                Color = categoryDto.Color,
                IconCssClass = categoryDto.IconCssClass,
            };
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
            var result = categories.Select(c => new GetCategoryDto
            {
                Id = c.CategoryId,
                Name = c.Name,
                Color = c.Color,
                IconCssClass = c.IconCssClass
            }).ToList();
            return result;
        }

        public async Task<GetCategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                throw new ArgumentException();
            }
            var result = new GetCategoryDto()
            {
                Id = category.CategoryId,
                Name = category.Name,
                Color = category.Color,
                IconCssClass = category.IconCssClass
            };
            return result;
        }

        public async Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto)
        {
            var existingCategory = await _repositoryManager.CategoryRepository.GetByIdAsync(id);
            if (existingCategory is null || existingCategory.CategoryId != categoryDto.Id)
            {
                return false;
            }
            existingCategory.Name = categoryDto.Name;
            existingCategory.Color = categoryDto.Color;
            existingCategory.IconCssClass = categoryDto.IconCssClass;
            _repositoryManager.CategoryRepository.Update(existingCategory);
            await _repositoryManager.CategoryRepository.SaveAsync();
            return true;
        }
    }
}
