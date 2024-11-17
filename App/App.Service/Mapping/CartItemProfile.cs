using App.Data.Data.Entities;
using App.Service.Models.CartItemDTOs;
using AutoMapper;

namespace App.Service.Mapping
{
    internal class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<AddCartItemDto, CartItemEntity>();
            CreateMap<CartItemEntity, GetCartItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.ProductImage, opt => opt.MapFrom(src => src.Product.ProductImages.Count != 0 ? src.Product.ProductImages.First().Url : null));
            CreateMap<UpdateCartItemDto, CartItemEntity>();
        }
    }
}
