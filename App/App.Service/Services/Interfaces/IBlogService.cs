using App.Service.Models.BlogDTOs;

namespace App.Service.Services.Interfaces
{
   public interface IBlogService
    {
        Task<IEnumerable<BlogDto>> GetAllBlogsAsync();
    }
}
