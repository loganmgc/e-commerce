using Microsoft.AspNetCore.Mvc;
using App.Service.Models.ProductDTOs;
using App.Service.Services.Interfaces;
using App.Eticaret.Models.ViewModels.Product;
using App.Eticaret.Models.ViewModels.Category;
using App.Service.Models.ProductCommentDTOs;
using App.Eticaret.Models.ViewModels.Discount;

namespace App.Eticaret.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Route("/product")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
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
            return View();
        }

        [Route("/product")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
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
                return View(product);
            }
            var productDto = new AddProductDto
            {
                Name = product.Name,
                Details = product.Details,
                Price = product.Price,
                StockAmount = product.StockAmount,
                CategoryId = product.CategoryId,
                DiscountId = product.DiscountId,
                SellerId = product.SellerId,
            };
            await _serviceManager.ProductService.AddProductAsync(productDto);
            TempData["SuccessMessage"] = "Product has been added successfully.";
            return RedirectToAction("Create");
        }

        [Route("/product/{productId:int}/edit")]
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int productId)
        {
            var existingProduct = await _serviceManager.ProductService.GetProductByIdAsync(productId);
            if (existingProduct is null)
            {
                return RedirectToAction("Index", "Home");
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

            var product = new UpdateProductViewModel()
            {
                ProductId = existingProduct.ProductId,
                Name = existingProduct.Name,
                Details = existingProduct.Details,
                Price = existingProduct.Price,
                StockAmount = existingProduct.StockAmount,
                CategoryId = existingProduct.CategoryId,
                DiscountId = existingProduct.DiscountId,
            };
            return View(product);
        }

        [Route("/product/{productId:int}/edit")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int productId, [FromForm] UpdateProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
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
                return View(product);
            }
            var productDto = new UpdateProductDto()
            {
                Id = product.ProductId,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Details = product.Details,
                StockAmount = product.StockAmount,
            };
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
            if (!ModelState.IsValid)
            {

            }
            var comment = new AddCommentDto()
            {
                ProductId = newComment.ProductId,
                UserId = newComment.UserId,
                Text = newComment.Text,
                StarCount = newComment.StarCount
            };
            await _serviceManager.ProductCommentService.AddCommentAsync(comment);

            return RedirectToAction(nameof(HomeController.ProductDetail), "Home", new { productId });
        }
    }
}