using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Helpers;
using App.Service.Models.ProductCommentDTOs;
using App.Service.Services.Interfaces;

namespace App.Service.Services.Implementations
{
    public class ProductCommentService : IProductCommentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ProductCommentHelper _productCommentHelper;

        public ProductCommentService(IRepositoryManager repositoryManager, ProductCommentHelper productCommentHelper)
        {
            _repositoryManager = repositoryManager;
            _productCommentHelper = productCommentHelper;
        }

        public async Task AddCommentAsync(AddCommentDto commentDto)
        {
            var comment = new ProductCommentEntity()
            {
                UserId = commentDto.UserId,
                ProductId = commentDto.ProductId,
                Text = commentDto.Text,
                StarCount = commentDto.StarCount,
                IsConfirmed = true
            };
            await _repositoryManager.ProductCommentRepository.AddAsync(comment);
            await _repositoryManager.ProductCommentRepository.SaveAsync();
        }

        public async Task<bool> ApproveCommentAsync(int id)
        {
            var existingComment = await _repositoryManager.ProductCommentRepository.GetByIdAsync(id);
            if (existingComment is null)
            {
                return false;
            }
            existingComment.IsConfirmed = true;
            _repositoryManager.ProductCommentRepository.Update(existingComment);
            await _repositoryManager.ProductCommentRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var existingComment = await _repositoryManager.ProductCommentRepository.GetByIdAsync(id);
            if (existingComment is null)
            {
                return false;
            }
            _repositoryManager.ProductCommentRepository.Delete(existingComment);
            await _repositoryManager.ProductCommentRepository.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<GetCommentDto>> GetAllCommentsAsync()
        {
            var comments = await _repositoryManager.ProductCommentRepository.GetAllAsync();
            return _productCommentHelper.CommentsList(comments);
        }

        public async Task<IEnumerable<GetCommentDto?>> GetAllCommentsByProductIdAsync(int productId)
        {
            var comments = await _repositoryManager.ProductCommentRepository.GetAllCommentsByProductIdAsync(productId);
            return _productCommentHelper.CommentsList(comments);
        }

        public async Task<IEnumerable<GetCommentDto?>> GetAllCommentsByUserIdAsync(int userId)
        {
            var comments = await _repositoryManager.ProductCommentRepository.GetAllCommentsByUserIdAsync(userId);
            return _productCommentHelper.CommentsList(comments);
        }

        public async Task<IEnumerable<GetCommentDto?>> GetAllUnapprovedCommentsAsync()
        {
            var comments = await _repositoryManager.ProductCommentRepository.GetAllUnapprovedCommentsAsync();
            var commentDto = comments.Select(c => new GetCommentDto
            {
                ProductCommentId = c.ProductCommentId,
                ProductId = c.ProductId,
                ProductName = c.Product.Name,
                UserId = c.UserId,
                UserName = $"{c.User.FirstName} {c.User.LastName}",
                Text = c.Text,
                StarCount = c.StarCount,
                CreatedAt = c.CreatedAt
            }).ToList();
            return commentDto;
        }

        public async Task<GetCommentDto?> GetCommentByIdAsync(int id)
        {
            var comment = await _repositoryManager.ProductCommentRepository.GetByIdAsync(id);
            if (comment is null)
            {
                throw new ArgumentException();
            }
            var result = new GetCommentDto()
            {
                ProductCommentId = comment.ProductCommentId,
                UserId = comment.UserId,
                UserName = $"{comment.User.FirstName} {comment.User.LastName}",
                ProductId = comment.ProductId,
                ProductName = comment.Product.Name,
                Text = comment.Text,
                StarCount = comment.StarCount,
                CreatedAt = comment.CreatedAt
            };
            return result;
        }

        public async Task<bool> UpdateCommentAsync(int id, UpdateCommentDto commentDto)
        {
            var existingComment = await _repositoryManager.ProductCommentRepository.GetByIdAsync(id);
            if (existingComment is null || existingComment.ProductCommentId != commentDto.ProductCommentId)
            {
                return false;
            }
            existingComment.Text = commentDto.Text;
            existingComment.StarCount = commentDto.StarCount;
            _repositoryManager.ProductCommentRepository.Update(existingComment);
            await _repositoryManager.ProductCommentRepository.SaveAsync();
            return true;
        }
    }
}
