using App.Eticaret.Models.ViewModels.Auth;
using App.Eticaret.Models.ViewModels.Profile;
using App.Service.Models.UserDTOs;
using AutoMapper;

namespace App.Eticaret.Mapping
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserViewModel, AddUserDto>();
            CreateMap<LoginViewModel, LoginUserDto>();
            CreateMap<GetUserWithoutIdDto, ProfileDetailsViewModel>();
            CreateMap<ProfileDetailsViewModel, UpdateUserDto>();
        }
    }
}
