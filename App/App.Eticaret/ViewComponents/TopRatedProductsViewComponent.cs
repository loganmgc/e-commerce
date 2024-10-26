using App.Eticaret.Models.ViewModels.Product;
using App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.ViewComponents
{
    public class TopRatedProductsViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public TopRatedProductsViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _serviceManager.ProductService.GetFilteredProductsAsync(6, "TopRated");
            var viewModel = new OwlCarouselViewModel
            {
                Title = "Top Rated Products",
                Items = products.Select(p => new ProductListingViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = p.CategoryName,
                    DiscountPercentage = p.DiscountPercentage,
                    ImageUrl = p.ImageUrl
                }).ToList()
            };
            return View(viewModel);
        }
    }
}
