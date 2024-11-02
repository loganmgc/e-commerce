using App.Eticaret.Models.ViewModels.Blog;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.ViewComponents
{
    public class FromTheBlogViewComponent : BaseViewComponent
    {
        public FromTheBlogViewComponent(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _serviceManager.BlogService.GetAllBlogsAsync();
            var viewModel = _mapper.Map<IEnumerable<BlogSummaryViewModel>>(blogs);
            return View(viewModel);
        }
    }
}
