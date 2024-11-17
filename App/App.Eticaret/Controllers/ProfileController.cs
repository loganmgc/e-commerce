using App.Eticaret.Models.ViewModels.Profile;
using App.Service.Models.UserDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {

        public ProfileController(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }

        [Route("/profile")]
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var userDto = await _serviceManager.UserService.GetUserByIdAsync(GetUserId().Value);
            if (userDto is null)
            {
                return RedirectToAction("Index", "Home");
            }
            var userView = _mapper.Map<ProfileDetailsViewModel>(userDto);
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
            var user = _mapper.Map<UpdateUserDto>(editMyProfileModel);
            user.UserId = GetUserId().Value;
            await _serviceManager.UserService.UpdateUserAsync(user);
            return RedirectToAction(nameof(Details));
        }

        [Route("/my-orders")]
        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var orders = await _serviceManager.OrderService.GetOrdersByUserIdAsync(GetUserId().Value);
            if (orders is null)
            {
                ViewBag.ErrorMessage = "You don't have any orders";
            }
            var viewModel = _mapper.Map<IEnumerable<MyOrdersViewModel>>(orders);
            return View(viewModel);
        }

        [Route("/my-products")]
        [HttpGet]
        [Authorize(Roles = "seller")]
        public async Task<IActionResult> MyProducts()
        {
            var productDto = await _serviceManager.ProductService.GetProductsBySellerIdAsync(GetUserId().Value);
            if (productDto is null)
            {
                ViewBag.Error = "You don't have any product. Start adding products";
                return View();
            }
            var productListViewModel = _mapper.Map<IEnumerable<MyProductsViewModel>>(productDto);
            return View(productListViewModel);
        }
    }
}