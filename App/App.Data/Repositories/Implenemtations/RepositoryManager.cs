using App.Data.Repositories.Interfaces;

namespace App.Data.Repositories.Implenemtations
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _dbContext;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductCommentRepository _productCommentRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IContactFormRepository _contactFormRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public RepositoryManager(AppDbContext dbContext, IProductRepository productRepository, ICategoryRepository categoryRepository, IProductCommentRepository productCommentRepository, IBlogRepository blogRepository, IContactFormRepository contactFormRepository, IDiscountRepository discountRepository, IUserRepository userRepository, ICartItemRepository cartItemRepository, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productCommentRepository = productCommentRepository;
            _blogRepository = blogRepository;
            _contactFormRepository = contactFormRepository;
            _discountRepository = discountRepository;
            _userRepository = userRepository;
            _cartItemRepository = cartItemRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }
        public IProductRepository ProductRepository => _productRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public IProductCommentRepository ProductCommentRepository => _productCommentRepository;

        public IBlogRepository BlogRepository => _blogRepository;

        public IContactFormRepository ContactFormRepository => _contactFormRepository;

        public IDiscountRepository IDiscountRepository => _discountRepository;

        public IUserRepository UserRepository => _userRepository;

        public ICartItemRepository CartItemRepository => _cartItemRepository;

        public IOrderRepository OrderRepository => _orderRepository;

        public IOrderItemRepository OrderItemRepository => _orderItemRepository;
    }
}
