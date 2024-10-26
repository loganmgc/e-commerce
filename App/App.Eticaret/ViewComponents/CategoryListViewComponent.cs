using App.Eticaret.Models.ViewModels.Category;
using App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public CategoryListViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync();
            var viewModel = categories.Select(c => new CategoryViewModel
            {
                CategoryId = c.Id,
                CategoryName = c.Name,
                Color = c.Color,
                IconCssClass = c.IconCssClass
            }).ToList();
            return View(viewModel);
        }
    }
}
