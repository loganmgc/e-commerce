using App.Eticaret.Models.ViewModels.Category;
using App.Service.Models.CategoryDTOs;
using AutoMapper;

namespace App.Eticaret.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<GetCategoryDto, CategoryViewModel>();
            CreateMap<CategoryDto, CategorySliderViewModel>();
        }
    }
}
