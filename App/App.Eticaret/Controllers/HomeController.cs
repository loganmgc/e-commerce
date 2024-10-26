using App.Eticaret.Models.ViewModels.ContactForm;
using App.Eticaret.Models.ViewModels.Product;
using App.Service.Models.ContactFormDTOs;
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
        public async Task<IActionResult> Contact([FromForm] CreateContactFormMessageViewModel newContactMessage)
        {
            if (!ModelState.IsValid)
            {
                return View(newContactMessage);
            }

            var contactFormDto = new AddContactFormDto
            {
                Name = newContactMessage.Name,
                Email = newContactMessage.Email,
                Message = newContactMessage.Message,
            };
            await _serviceManager.ContactFormService.AddContactForm(contactFormDto);
            ViewBag.SuccessMessage = "Your message has been sent successfully.";
            return View();
        }

        [Route("/product/list")]
        [HttpGet]
        public async Task<IActionResult> Listing()
        {
            var products = await _serviceManager.ProductService.GetFeaturedProductsAsync();
            var productList = products.Select(p => new ProductListingViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.CategoryName,
                DiscountPercentage = p.DiscountPercentage,
                ImageUrl = p.ImageUrl
            }).ToList();

            return View(productList);
        }

        [Route("/product/{productId:int}/details")]
        [HttpGet]
        public async Task<IActionResult> ProductDetail([FromRoute] int productId)
        {
            var product = await _serviceManager.ProductService.GetProductByIdAsync(productId);
            if(product is null)
            {
                return RedirectToAction("Listing");
            }
            var comments = await _serviceManager.ProductCommentService.GetAllCommentsByProductIdAsync(productId);
            ViewBag.Product = new HomeProductDetailViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Details = product.Details,
                Price = product.Price,
                DiscountPercentage = product.DiscountPercentage,
                DiscountedPrice = product.DiscountedPrice,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                SellerName = product.SellerName,
                StockAmount = product.StockAmount,
                ImageUrls = product.ImageUrls,
                Reviews = comments.Select(c => new GetProductCommentViewModel
                {
                    ProductCommentId = c.ProductCommentId,
                    Text = c.Text,
                    StarCount = c.StarCount,
                    Username = c.UserName,
                    CreatedAt = DateTime.Now,
                }).ToArray()
            };
            return View();           
        }
    }
}