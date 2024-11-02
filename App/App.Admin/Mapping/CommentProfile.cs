using App.Admin.Models.ViewModels.Comment;
using App.Service.Models.ProductCommentDTOs;
using AutoMapper;

namespace App.Admin.Mapping
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<GetCommentDto, CommentListViewModel>();
        }
    }
}
