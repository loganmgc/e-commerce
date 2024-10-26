using App.Eticaret.Models.ViewModels.Category;
using App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.ViewComponents
{
    public class CategoriesSliderViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public CategoriesSliderViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryDto = await _serviceManager.CategoryService.GetCategoriesForSliderAsync();
            var categories = categoryDto.Select(c => new CategorySliderViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Color = c.Color,
                IconCssClass = c.IconCssClass,
                ImageUrl = c.ImageUrl
            }).ToList();
            return View(categories);
        }
    }
}
