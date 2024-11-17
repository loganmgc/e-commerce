using App.Data.Data.Entities;
using App.Service.Models.OrderDTOs;
using AutoMapper;
using Microsoft.Data.SqlClient;

namespace App.Service.Mapping
{
    internal class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderEntity, OrderDetailsDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));

            CreateMap<OrderItemEntity, OrderItemDetailsDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice));
            CreateMap<OrderEntity, MyOrderDto>()
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.UnitPrice * oi.Quantity)))
                .ForMember(dest => dest.TotalProducts, opt => opt.MapFrom(src => src.OrderItems.Count))
                .ForMember(dest => dest.TotalQuantity, opt => opt.MapFrom(src => src.OrderItems.Sum(oi => oi.Quantity)));
        }
    }
}
