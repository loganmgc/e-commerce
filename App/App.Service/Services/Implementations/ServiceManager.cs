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
        private readonly IUserService _userService;
        private readonly ICartItemService _cartItemService;
        private readonly IEmailService _emailService;
        private readonly IOrderService _orderService;

        public ServiceManager(IProductService productService, ICategoryService categoryService, IProductCommentService productCommentService, IBlogService blogService, IContactFormService contactFormService, IDiscountService discountService, IUserService userService, ICartItemService cartItemService, IEmailService emailService, IOrderService orderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productCommentService = productCommentService;
            _blogService = blogService;
            _contactFormService = contactFormService;
            _discountService = discountService;
            _userService = userService;
            _cartItemService = cartItemService;
            _emailService = emailService;
            _orderService = orderService;
        }

        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public IProductCommentService ProductCommentService => _productCommentService;

        public IBlogService BlogService => _blogService;

        public IContactFormService ContactFormService => _contactFormService;

        public IDiscountService DiscountService => _discountService;

        public IUserService UserService => _userService;

        public ICartItemService CartItemService => _cartItemService;

        public IEmailService EmailService => _emailService;

        public IOrderService OrderService => _orderService;
    }
}
