using App.Data.Data.Entities;
using App.Service.Models.CategoryDTOs;
using AutoMapper;

namespace App.Service.Mapping
{
    internal class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>();
            CreateMap<CategoryEntity, GetCategoryDto>();
            CreateMap<AddCategoryDto, CategoryEntity>();
            CreateMap<UpdateCategoryDto, CategoryEntity>();
            CreateMap<ProductEntity, CategoryDto>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.CategoryId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Category.Color))
            .ForMember(dest => dest.IconCssClass, opt => opt.MapFrom(src => src.Category.IconCssClass))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ProductImages.Any() ? src.ProductImages.First().Url : null));
        }
    }
}
