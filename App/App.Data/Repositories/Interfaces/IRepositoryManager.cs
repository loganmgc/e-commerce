namespace App.Data.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductCommentRepository ProductCommentRepository { get; }
    }
}
