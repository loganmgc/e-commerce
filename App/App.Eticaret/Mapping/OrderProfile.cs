using App.Eticaret.Models.ViewModels.Order;
using App.Eticaret.Models.ViewModels.Profile;
using App.Service.Models.OrderDTOs;
using AutoMapper;

namespace App.Eticaret.Mapping
{
    internal class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CheckoutViewModel, AddOrderDto>();
            CreateMap<OrderDetailsDto, OrderDetailsViewModel>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<OrderItemDetailsDto, OrderItemViewModel>();
            CreateMap<MyOrderDto, MyOrdersViewModel>();
        }
    }
}
