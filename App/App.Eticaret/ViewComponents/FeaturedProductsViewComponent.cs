using App.Eticaret.Models.ViewModels.Product;
using App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.ViewComponents
{
    public class FeaturedProductsViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public FeaturedProductsViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _serviceManager.ProductService.GetFeaturedProductsAsync();
            var featuredPro = products.Select(p => new ProductListingViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.CategoryName,
                DiscountPercentage = p.DiscountPercentage,
                ImageUrl = p.ImageUrl,
            }).ToList();
            return View(featuredPro);
        }
    }
}
