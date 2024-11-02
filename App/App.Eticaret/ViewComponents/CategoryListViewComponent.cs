using App.Eticaret.Models.ViewModels.Category;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.ViewComponents
{
    public class CategoryListViewComponent : BaseViewComponent
    {
        public CategoryListViewComponent(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync();
            var viewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return View(viewModel);
        }
    }
}
