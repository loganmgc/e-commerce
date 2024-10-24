using App.Data.Data.Entities;
using App.Service.Models.ProductCommentDTOs;

namespace App.Service.Helpers
{
    public class ProductCommentHelper
    {
        public List<GetCommentDto> CommentsList(IEnumerable<ProductCommentEntity?> comments)
        {
            return comments
                .Where(c => c.IsConfirmed == true)
                .Select(comment => new GetCommentDto()
                {
                    ProductCommentId = comment.ProductCommentId,
                    UserId = comment.UserId,
                    UserName = comment.User.FirstName,
                    ProductId = comment.ProductId,
                    ProductName = comment.Product.Name,
                    Text = comment.Text,
                    StarCount = comment.StarCount,
                    CreatedAt = comment.CreatedAt
                }).ToList();
        }
    }
}
