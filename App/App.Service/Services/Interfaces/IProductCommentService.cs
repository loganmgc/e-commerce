using App.Service.Models.CategoryDtos;
using App.Service.Models.ProductCommentDTOs;

namespace App.Service.Services.Interfaces
{
   public interface IProductCommentService
    {
        Task<IEnumerable<GetCommentDto>> GetAllCommentsAsync();
        Task<IEnumerable<GetCommentDto?>> GetAllCommentsByUserIdAsync(int userId);
        Task<IEnumerable<GetCommentDto?>> GetAllCommentsByProductIdAsync(int productId);
        Task<GetCommentDto?> GetCommentByIdAsync(int id);
        Task AddCommentAsync(AddCommentDto commentDto);
        Task<bool> UpdateCommentAsync(int id, UpdateCommentDto commentDto);
        Task<bool> DeleteCommentAsync(int id);
    }
}
