namespace App.Service.Services.Interfaces
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IProductCommentService ProductCommentService { get; }
        IBlogService BlogService { get; }
        IContactFormService ContactFormService { get; }
        IDiscountService DiscountService { get; }
        IUserService UserService { get; }
        ICartItemService CartItemService { get; }
    }
}
