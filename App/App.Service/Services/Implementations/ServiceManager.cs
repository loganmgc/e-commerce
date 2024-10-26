using App.Service.Services.Interfaces;

namespace App.Service.Services.Implementations
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductCommentService _productCommentService;
        private readonly IBlogService _blogService;
        private readonly IContactFormService _contactFormService;
        private readonly IDiscountService _discountService;

        public ServiceManager(IProductService productService, ICategoryService categoryService, IProductCommentService productCommentService, IBlogService blogService, IContactFormService contactFormService, IDiscountService discountService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productCommentService = productCommentService;
            _blogService = blogService;
            _contactFormService = contactFormService;
            _discountService = discountService;
        }

        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public IProductCommentService ProductCommentService => _productCommentService;

        public IBlogService BlogService => _blogService;

        public IContactFormService ContactFormService => _contactFormService;

        public IDiscountService DiscountService => _discountService;
    }
}
