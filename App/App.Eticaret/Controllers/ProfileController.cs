using App.Eticaret.Models.ViewModels.Category;
using App.Eticaret.Models.ViewModels.Discount;
using App.Eticaret.Models.ViewModels.Profile;
using App.Service.Models.UserDTOs;
using App.Service.Services.Interfaces;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProfileController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Route("/profile")]
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var userDto = await _serviceManager.UserService.GetUserByIdAsync(int.Parse(User.FindFirst(JwtClaimTypes.Id).Value));
            if (userDto is null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userView = new ProfileDetailsViewModel
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                CreatedAt = userDto.CreatedAt
            };

            return View(userView);
        }

        [Route("/profile")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] ProfileDetailsViewModel editMyProfileModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Details));
            }
            var user = new UpdateUserDto
            {
                UserId = int.Parse(User.FindFirst(JwtClaimTypes.Id).Value),
                FirstName = editMyProfileModel.FirstName,
                LastName = editMyProfileModel.LastName
            };
            await _serviceManager.UserService.UpdateUserAsync(user);
            return RedirectToAction(nameof(Details));
        }

        [Route("/my-orders")]
        [HttpGet]
        public IActionResult MyOrders()
        {
            return View();
        }

        [Route("/my-products")]
        [HttpGet]
        [Authorize(Roles = "seller")]
        public async Task<IActionResult> MyProducts()
        {
            var productDto = await _serviceManager.ProductService.GetProductsBySellerIdAsync(int.Parse(User.FindFirst(JwtClaimTypes.Id).Value));
            if (productDto is null)
            {
                ViewBag.Error = "You don't have any product. Start adding products";
                return View();
            }
            var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories.Select(c => new CategoryViewModel
            {
                CategoryId = c.Id,
                CategoryName = c.Name,
                Color = c.Color,
                IconCssClass = c.IconCssClass
            });
            var discounts = await _serviceManager.DiscountService.GetDiscountsForCreateProductAsync();
            ViewBag.Discounts = discounts.Select(d => new DiscountSelectViewModel
            {
                Id = d.DiscountId,
                Rate = d.DiscountRate
            });
            var productListViewModel = productDto.Select(p => new MyProductsViewModel
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price,
                DiscountId = p.DiscountId,
                DiscountPercentage = p.DiscountPercentage,
                DiscountedPrice = p.DiscountedPrice,
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                StockAmount = p.StockAmount,
                ImageUrls = p.ImageUrl
            }).ToList();
            return View(productListViewModel);
        }
    }
}