using App.Eticaret.Models.ViewModels.Category;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.ViewComponents
{
    public class CategoriesSliderViewComponent : BaseViewComponent
    {
        public CategoriesSliderViewComponent(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryDto = await _serviceManager.CategoryService.GetCategoriesForSliderAsync();
            var categories = _mapper.Map<IEnumerable<CategorySliderViewModel>>(categoryDto);
            return View(categories);
        }
    }
}
