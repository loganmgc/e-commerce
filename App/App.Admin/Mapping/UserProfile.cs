using App.Admin.Models.ViewModels;
using App.Admin.Models.ViewModels.User;
using App.Service.Models.UserDTOs;
using AutoMapper;

namespace App.Admin.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginViewModel, LoginUserDto>();
            CreateMap<GetUserWithIdDto, UserListViewModel>();
        }
    }
}
