using App.Service.Models.CategoryDtos;
using App.Service.Models.CategoryDTOs;

namespace App.Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryDto>> GetAllCategoriesAsync();
        Task<GetCategoryDto> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(AddCategoryDto categoryDto);
        Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto);
        Task<bool> DeleteCategoryAsync(int id);
        Task<IEnumerable<CategoryDto>> GetCategoriesForSliderAsync();
    }
}
