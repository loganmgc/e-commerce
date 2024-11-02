using App.Data.Data.Entities;
using App.Service.Models.DiscountDTOs;
using AutoMapper;

namespace App.Service.Mapping
{
    internal class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<DiscountEntity, GetDiscountDto>();
        }
    }
}
