using App.Data.Data.Entities;
using App.Eticaret.Models.ViewModels.Product;
using App.Eticaret.Models.ViewModels.Profile;
using App.Service.Models.ProductDTOs;
using AutoMapper;

namespace App.Eticaret.Mapping
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductViewModel, AddProductDto>();
            CreateMap<GetProductDto, UpdateProductViewModel>();
            CreateMap<UpdateProductViewModel, UpdateProductDto>();
            CreateMap<ProductListingDto, ProductListingViewModel>();
            CreateMap<GetProductDto, HomeProductDetailViewModel>()
                .ForMember(dest => dest.Reviews, opt => opt.Ignore());
            CreateMap<GetProductsBySellerIdDto, MyProductsViewModel>()
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}
