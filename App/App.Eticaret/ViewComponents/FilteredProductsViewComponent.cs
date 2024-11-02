using App.Eticaret.Models.ViewModels.Product;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.ViewComponents
{
    public class FilteredProductsViewComponent : BaseViewComponent
    {
        public FilteredProductsViewComponent(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(string filterType, int count = 6)
        {
            var products = await _serviceManager.ProductService.GetFilteredProductsAsync(count, filterType);
            if (filterType == "TopRated")
                filterType = "Top Rated";
            var viewModel = new OwlCarouselViewModel
            {
                Title = $"{filterType} Products",
                Items = _mapper.Map<List<ProductListingViewModel>>(products)
            };
            return View(viewModel);
        }
    }
}
