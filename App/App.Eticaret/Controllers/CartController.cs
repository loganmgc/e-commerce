using App.Eticaret.Models.ViewModels.Cart;
using App.Service.Models.CartItemDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.Controllers
{
    [Authorize]
    public class CartController : BaseController
    {
        public CartController(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }

        [Route("/add-to-cart/{productId:int}")]
        [HttpGet]
        public async Task<IActionResult> AddProduct([FromRoute] int productId)
        {
            var cartItemDto = new AddCartItemDto
            {
                ProductId = productId,
                UserId = int.Parse(User.FindFirst(JwtClaimTypes.Id).Value),
                Quantity = 1
            };
            await _serviceManager.CartItemService.AddProductToCartAsync(cartItemDto);
            var prevUrl = Request.Headers.Referer.FirstOrDefault();

            if (prevUrl is null)
            {
                return RedirectToAction(nameof(Edit));
            }

            return Redirect(prevUrl);
        }

        [Authorize]
        [Route("/cart")]
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var cart = await _serviceManager.CartItemService.GetCartItemsByUserIdAsync(int.Parse(User.FindFirst(JwtClaimTypes.Id).Value));
            if (cart is null)
            {
                ViewBag.Error = "";
                return View();
            }
            var viewModel = _mapper.Map<IEnumerable<CartItemListingViewModel>>(cart);
            
            return View(viewModel);
        }

        [Route("/cart")]
        [HttpPost]
        public IActionResult Edit([FromForm] CartItemListingViewModel editCartViewModel)
        {

            return View();
        }


        [Route("/cart/{cartItemId:int}/delete")]
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute]int cartItemId)
        {
            var result = await _serviceManager.CartItemService.DeleteProductFromCartAsync(cartItemId);
            if (!result)
            {
                TempData["ErrorMessage"] = "An error has occurred";
            }
            else
            {
                TempData["SuccessMessage"] = "Cart successfully updated";
            }
            return RedirectToAction(nameof(Edit));
        }

    }
}