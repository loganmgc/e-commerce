using App.Data.Repositories.Interfaces;
using App.Service.Models.BlogDTOs;
using App.Service.Services.Interfaces;

namespace App.Service.Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BlogService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<BlogDto>> GetAllBlogsAsync()
        {
            var blogs = await _repositoryManager.BlogRepository.GetAllBlogsAsync();
            var blogSummary = blogs.OrderByDescending(b => b.CreatedAt)
                .Take(3)
                .Select(b => new BlogDto
                {
                    Id = b.BlogId,
                    Title = b.Title,
                    Content = b.Content,
                    ImageUrl = b.ImageUrl,
                    CommentCount = b.BlogComments.Count,
                    CreatedAt = b.CreatedAt
                }).ToList();
            return blogSummary;
        }
    }
}
