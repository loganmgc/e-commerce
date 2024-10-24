using App.Service.Services.Interfaces;

namespace App.Service.Services.Implementations
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductCommentService _productCommentService;

        public ServiceManager(IProductService productService, ICategoryService categoryService, IProductCommentService productCommentService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _productCommentService = productCommentService;
        }

        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public IProductCommentService ProductCommentService => _productCommentService;
    }
}
