using App.Admin.Models.ViewModels.Category;
using App.Service.Models.CategoryDTOs;
using AutoMapper;

namespace App.Admin.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<GetCategoryDto, CategoryListViewModel>();
            CreateMap<CreateCategoryViewModel, AddCategoryDto>();
            CreateMap<GetCategoryDto, EditCategoryViewModel>();
            CreateMap<EditCategoryViewModel, UpdateCategoryDto>();
        }
    }
}
