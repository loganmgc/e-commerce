using App.Eticaret.Models.ViewModels.Blog;
using App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.ViewComponents
{
    public class FromTheBlogViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public FromTheBlogViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _serviceManager.BlogService.GetAllBlogsAsync();
            var viewModel = blogs.Select(b => new BlogSummaryViewModel
            {
                Id = b.Id,
                Title = b.Title,
                SummaryContent = b.Content.Substring(0,100),
                ImageUrl = b.ImageUrl,
                CommentCount = b.CommentCount,
                CreatedAt = b.CreatedAt
            }).ToList();
            return View(viewModel);
        }
    }
}
