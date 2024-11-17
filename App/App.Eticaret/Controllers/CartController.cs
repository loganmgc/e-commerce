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
        [Authorize(Roles = "buyer, seller")]
        [Route("/add-to-cart/{productId:int}")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromRoute] int productId, [FromForm] byte quantity = 1)
        {
            var cartItemDto = new AddCartItemDto
            {
                ProductId = productId,
                UserId = GetUserId().Value,
                Quantity = quantity
            };
            await _serviceManager.CartItemService.AddProductToCartAsync(cartItemDto);
            var prevUrl = Request.Headers.Referer.FirstOrDefault();

            if (prevUrl is null)
            {
                return RedirectToAction(nameof(Edit));
            }

            return Redirect(prevUrl);
        }

        [Authorize(Roles = "buyer, seller")]
        [Route("/cart")]
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var cart = await _serviceManager.CartItemService.GetCartItemsByUserIdAsync(GetUserId().Value);
            if (cart is null)
            {
                ViewBag.Error = "There's nothing in your cart. Start adding products to your cart";
                return View();
            }
            var viewModel = _mapper.Map<IEnumerable<CartItemListingViewModel>>(cart);

            return View(viewModel);
        }

        [Authorize(Roles = "buyer, seller")]
        [Route("/cart/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateCart(int cartItemId, byte quantity)
        {
            var cartItem = await _serviceManager.CartItemService.UpdateCartItemAsync(new UpdateCartItemDto { CartItemId = cartItemId, Quantity = quantity });
            if (cartItem is null)
            {
                TempData["Error"] = "Something went wrong. try again";
                return RedirectToAction(nameof(Edit));
            }
            var model = _mapper.Map<CartItemListingViewModel>(cartItem);
            return View(model);
        }

        [Authorize(Roles = "buyer, seller")]
        [Route("/cart/{cartItemId:int}/delete")]
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int cartItemId)
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

        [Route("/chechout")]
        [HttpGet]
        public async Task<IActionResult> CheckOut()
        {
            var cart = await _serviceManager.CartItemService.GetCartItemsByUserIdAsync(GetUserId().Value);
            if (cart is null)
            {
                ViewBag.Error = "There's nothing in your cart. Start adding products to your cart";
                return View();
            }
            var viewModel = _mapper.Map<IEnumerable<CartItemListingViewModel>>(cart);

            return View(viewModel);
        }
    }
}