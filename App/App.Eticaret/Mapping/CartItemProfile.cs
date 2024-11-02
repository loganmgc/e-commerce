using App.Eticaret.Models.ViewModels.Cart;
using App.Service.Models.CartItemDTOs;
using AutoMapper;

namespace App.Eticaret.Mapping
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<GetCartItemDto, CartItemListingViewModel>();
        }
    }
}
