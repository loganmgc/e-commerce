using App.Data.Data.Entities;
using App.Service.Models.ProductDTOs;
using AutoMapper;

namespace App.Service.Mapping
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, GetProductDto>()
                .ForMember(dest => dest.SellerName, opt => opt.MapFrom(src => $"{src.Seller.FirstName} {src.Seller.LastName}"))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.Discount == null ? null : (decimal?)src.Discount.DiscountRate))
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ProductImages.Select(i => i.Url).ToArray()));
            CreateMap<ProductEntity, GetProductsBySellerIdDto>()
                .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.Discount == null ? null : (decimal?)src.Discount.DiscountRate))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ProductImages.First().Url));
            CreateMap<AddProductDto, ProductEntity>();
            CreateMap<UpdateProductDto, ProductEntity>();
            CreateMap<ProductEntity, ProductListingDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.Discount == null ? null : (decimal?)src.Discount.DiscountRate))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ProductImages.Count != 0 ? src.ProductImages.First().Url : null));
        }
    }
}
