using App.Data.Data.Entities;
using App.Eticaret.Models.ViewModels.ProductComment;
using App.Service.Models.ProductCommentDTOs;
using AutoMapper;

namespace App.Eticaret.Mapping
{
    public class ProductCommentProfile : Profile
    {
        public ProductCommentProfile()
        {
            CreateMap<AddProductCommentViewModel, AddProductCommentDto>();
            CreateMap<ProductCommentEntity, GetProductCommentViewModel>();
        }
    }
}
