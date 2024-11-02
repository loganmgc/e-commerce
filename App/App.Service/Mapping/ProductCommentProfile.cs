using App.Data.Data.Entities;
using App.Service.Models.ProductCommentDTOs;
using AutoMapper;

namespace App.Service.Mapping
{
    internal class ProductCommentProfile : Profile
    {
        public ProductCommentProfile()
        {
            CreateMap<AddProductCommentDto, ProductCommentEntity>();
            CreateMap<ProductCommentEntity, GetCommentDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));
        }
    }
}
