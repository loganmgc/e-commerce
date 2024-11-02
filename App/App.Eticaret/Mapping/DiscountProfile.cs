using App.Eticaret.Models.ViewModels.Discount;
using App.Service.Models.DiscountDTOs;
using AutoMapper;

namespace App.Eticaret.Mapping
{
    internal class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<GetDiscountDto, DiscountSelectViewModel>();
        }
    }
}
