using App.Eticaret.Models.ViewModels.Product;
using App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public HomeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("/about-us")]
        [HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("/contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("/contact")]
        [HttpPost]
        public IActionResult Contact([FromForm] object newContactMessageModel)
        {
            return View();
        }

        [Route("/product/list")]
        [HttpGet]
        public async Task<IActionResult> Listing()
        {
            var products = await _serviceManager.ProductService.GetAllEnableProductsAsync();
            var productList = products.Select(p => new GetProductListViewModel
            {
                ProductId = p.ProductId,
                CategoryId = p.CategoryId,
                ProductName = p.Name,
                CategoryName = p.CategoryName,
                Price = p.Price
            }).ToList();

            return View(productList);
        }

        [Route("/product/{productId:int}/details")]
        [HttpGet]
        public async Task<IActionResult> ProductDetail([FromRoute] int productId)
        {
            var (product, message) = await _serviceManager.ProductService.GetProductByIdAsync(productId);
            if (message is not null)
            {
                return RedirectToAction("Listing", "Home");
            }
            ViewBag.Product = new GetProductViewModel()
            {
                ProductId = product.ProductId,
                CategoryId = product.CategoryId,
                ProductName = product.Name,
                CategoryName = product.CategoryName,
                Price = product.Price,
                Details = product.Details,
                StockAmount = product.StockAmount,
                SellerId = product.SellerId,
                SellerName = product.SellerName
            };
            var comments = await _serviceManager.ProductCommentService.GetAllCommentsByProductIdAsync(productId);
            if (comments is null)
            {
                ViewBag.Empty = "Be the first to comment on this product";
                return View();
            }
            ViewBag.Comments = comments.Select(c => new GetProductCommentViewModel
            {
                ProductCommentId = c.ProductCommentId,
                UserId = c.UserId,
                UserName = c.UserName,
                Text = c.Text,
                StarCount = c.StarCount,
                CreatedAt = c.CreatedAt
            }).ToList();
            return View();
        }
    }
}