using App.Data.Repositories.Interfaces;
using App.Service.Models.BlogDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;

namespace App.Service.Services.Implementations
{
    public class BlogService :ServiceBase, IBlogService
    {
        public BlogService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<BlogDto>> GetAllBlogsAsync()
        {
            var blogs = await _repositoryManager.BlogRepository.GetAllBlogsAsync();
            var blogSummary = blogs
                .OrderByDescending(b => b.CreatedAt)
                .Take(3);
            return _mapper.Map<IEnumerable<BlogDto>>(blogSummary);
        }
    }
}
