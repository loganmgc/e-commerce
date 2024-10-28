namespace App.Data.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductCommentRepository ProductCommentRepository { get; }
        IBlogRepository BlogRepository { get; }
        IContactFormRepository ContactFormRepository { get; }
        IDiscountRepository IDiscountRepository { get; }
        IUserRepository UserRepository { get; }
        ICartItemRepository CartItemRepository { get; }
    }
}
