using App.Eticaret.Models.ViewModels.Product;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.ViewComponents
{
    public class FeaturedProductsViewComponent : BaseViewComponent
    {
        public FeaturedProductsViewComponent(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _serviceManager.ProductService.GetFeaturedProductsAsync();
            var featuredPro = _mapper.Map<IEnumerable<ProductListingViewModel>>(products);
            return View(featuredPro);
        }
    }
}
