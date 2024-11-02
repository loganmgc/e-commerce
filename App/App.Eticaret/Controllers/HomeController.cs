using App.Eticaret.Models.ViewModels.ContactForm;
using App.Eticaret.Models.ViewModels.Product;
using App.Eticaret.Models.ViewModels.ProductComment;
using App.Service.Models.ContactFormDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Eticaret.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
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

            var contactFormDto = _mapper.Map<AddContactFormDto>(newContactMessage);
            await _serviceManager.ContactFormService.AddContactForm(contactFormDto);
            ViewBag.SuccessMessage = "Your message has been sent successfully.";
            return View();
        }

        [Route("/product/list")]
        [HttpGet]
        public async Task<IActionResult> Listing()
        {
            var products = await _serviceManager.ProductService.GetFeaturedProductsAsync();
            var productList = _mapper.Map<IEnumerable<ProductListingViewModel>>(products);
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
            var productViewModel = _mapper.Map<HomeProductDetailViewModel>(product);
            var comments = await _serviceManager.ProductCommentService.GetAllCommentsByProductIdAsync(productId);
            productViewModel.Reviews = _mapper.Map<IEnumerable<GetProductCommentViewModel>>(comments).ToArray();
            ViewBag.Product = productViewModel;
            return View();           
        }
    }
}