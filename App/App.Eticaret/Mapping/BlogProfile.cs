using App.Eticaret.Models.ViewModels.Blog;
using App.Service.Models.BlogDTOs;
using AutoMapper;

namespace App.Eticaret.Mapping
{
    internal class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogDto, BlogSummaryViewModel>()
                .ForMember(dest => dest.SummaryContent, opt => opt.MapFrom(src => src.Content.Substring(0, 100)));
        }
    }
}
