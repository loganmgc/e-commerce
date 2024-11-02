using App.Data.Data.Entities;
using App.Service.Models.BlogDTOs;
using AutoMapper;

namespace App.Service.Mapping
{
    internal class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogEntity, BlogDto>()
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.BlogComments.Count));
        }
    }
}
