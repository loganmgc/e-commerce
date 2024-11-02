using App.Data.Data.Entities;
using App.Data.Repositories.Interfaces;
using App.Service.Helpers;
using App.Service.Models.ProductCommentDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;

namespace App.Service.Services.Implementations
{
    public class ProductCommentService : IProductCommentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ProductCommentHelper _productCommentHelper;
        private readonly IMapper _mapper;

        public ProductCommentService(IRepositoryManager repositoryManager, ProductCommentHelper productCommentHelper, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _productCommentHelper = productCommentHelper;
            _mapper = mapper;
        }

        public async Task AddCommentAsync(AddProductCommentDto commentDto)
        {
            var comment = _mapper.Map<ProductCommentEntity>(commentDto);
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

        public async Task<IEnumerable<GetCommentDto?>> GetAllCommentsByProductIdAsync(int productId)
        {
            var comments = await _repositoryManager.ProductCommentRepository.GetAllCommentsByProductIdAsync(productId);
            return _productCommentHelper.CommentsList(comments);
        }

        public async Task<IEnumerable<GetCommentDto?>> GetAllUnapprovedCommentsAsync()
        {
            var comments = await _repositoryManager.ProductCommentRepository.GetAllUnapprovedCommentsAsync();
            var commentDto = _mapper.Map<IEnumerable<GetCommentDto>>(comments);
            return commentDto;
        }
    }
}
