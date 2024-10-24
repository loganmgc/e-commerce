namespace App.Service.Services.Interfaces
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IProductCommentService ProductCommentService { get; }
    }
}
