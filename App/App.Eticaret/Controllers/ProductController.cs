using Microsoft.AspNetCore.Mvc;
using App.Service.Models.ProductDTOs;
using App.Service.Services.Interfaces;
using App.Eticaret.Models.ViewModels.Product;
using App.Eticaret.Models.ViewModels.Category;
using App.Service.Models.ProductCommentDTOs;
using App.Eticaret.Models.ViewModels.Discount;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using App.Eticaret.Models.ViewModels.ProductComment;

namespace App.Eticaret.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }

        [Route("/product")]
        [HttpGet]
        [Authorize(Roles = "seller")]
        public async Task<IActionResult> Create()
        {
            await SetViewBagsAsync();
            return View();
        }

        [Route("/product")]
        [HttpPost]
        [Authorize(Roles = "seller")]
        public async Task<IActionResult> Create([FromForm] CreateProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                await SetViewBagsAsync();
                return View(product);
            }           
            var productDto = _mapper.Map<AddProductDto>(product);
            productDto.SellerId = GetUserId().Value;
            await _serviceManager.ProductService.AddProductAsync(productDto);
            TempData["SuccessMessage"] = "Product has been added successfully.";
            return RedirectToAction("Create");
        }

        [Route("/product/{productId:int}/edit")]
        [HttpGet]
        [Authorize(Roles = "seller")]
        public async Task<IActionResult> Edit([FromRoute] int productId)
        {
            var existingProduct = await _serviceManager.ProductService.GetProductByIdAsync(productId);
            if (existingProduct is null)
            {
                return RedirectToAction("Index", "Home");
            }
            await SetViewBagsAsync();

            var product = _mapper.Map<UpdateProductViewModel>(existingProduct);
            return View(product);
        }

        [Route("/product/{productId:int}/edit")]
        [HttpPost]
        [Authorize(Roles = "seller")]
        public async Task<IActionResult> Edit([FromRoute] int productId, [FromForm] UpdateProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                await SetViewBagsAsync();
                return View(product);
            }

            var productDto = _mapper.Map<UpdateProductDto>(product);
            productDto.ProductId = productId;
            await _serviceManager.ProductService.UpdateAsync(productId, productDto);
            TempData["SuccessMessage"] = "Product has been updated successfully.";
            return RedirectToAction("Edit");
        }

        [Route("/product/{productId:int}/delete")]
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int productId)
        {
            var (result, message) = await _serviceManager.ProductService.DeleteProductAsync(productId);
            if (!result)
            {
                ViewBag.Error = message;
            }
            else
            {
                ViewBag.Success = message;
            }
            return View();
        }

        [Route("/product/{productId:int}/comment")]
        [HttpPost]
        public async Task<IActionResult> Comment([FromRoute] int productId, [FromForm] AddProductCommentViewModel newComment)
        {
            var currentProductId = TempData["CurrentProductId"] as int?;
            if(currentProductId != productId || !ModelState.IsValid)
            {
                return RedirectToAction(nameof(HomeController.ProductDetail), "Home", new { productId = currentProductId });
            }

            var commentDto = _mapper.Map<AddProductCommentDto>(newComment);
            commentDto.ProductId = productId;
            commentDto.UserId = GetUserId().Value;
            await _serviceManager.ProductCommentService.AddCommentAsync(commentDto);

            return RedirectToAction(nameof(HomeController.ProductDetail), "Home", new { productId });
        }

        [NonAction]
        private async Task SetViewBagsAsync()
        {
            var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync();
            ViewBag.Categories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            var discounts = await _serviceManager.DiscountService.GetDiscountsForCreateProductAsync();
            ViewBag.Discounts = _mapper.Map<IEnumerable<DiscountSelectViewModel>>(discounts);
        }
    }
}