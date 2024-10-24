using App.Data.Repositories.Interfaces;

namespace App.Data.Repositories.Implenemtations
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _dbContext;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductCommentRepository _productCommentRepository;

        public RepositoryManager(AppDbContext dbContext, IProductRepository productRepository, ICategoryRepository categoryRepository, IProductCommentRepository productCommentRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productCommentRepository = productCommentRepository;
        }
        public IProductRepository ProductRepository => _productRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public IProductCommentRepository ProductCommentRepository => _productCommentRepository;
    }
}
