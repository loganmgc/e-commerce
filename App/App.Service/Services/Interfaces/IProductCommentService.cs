using App.Service.Models.ProductCommentDTOs;

namespace App.Service.Services.Interfaces
{
   public interface IProductCommentService
    {
        Task<IEnumerable<GetCommentDto?>> GetAllCommentsByProductIdAsync(int productId);
        Task AddCommentAsync(AddProductCommentDto commentDto);
        Task<bool> DeleteCommentAsync(int id);
        Task<IEnumerable<GetCommentDto?>> GetAllUnapprovedCommentsAsync();
        Task<bool> ApproveCommentAsync(int id);
    }
}
