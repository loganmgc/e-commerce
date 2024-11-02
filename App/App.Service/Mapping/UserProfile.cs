using App.Data.Data.Entities;
using App.Service.Models.UserDTOs;
using AutoMapper;

namespace App.Service.Mapping
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserDto, UserEntity>();
            CreateMap<UserEntity, GetUserWithIdDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
            CreateMap<UserEntity, GetUserWithoutIdDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
            CreateMap<UpdateUserDto, UserEntity>();
        }
    }
}
