namespace App.Eticaret.Models.ViewModels.ProductComment
{
    public class ProductCommentsViewModel
    {
        public int ProductId { get; set; }
        public GetProductCommentViewModel[]? Comments { get; set; }
        public AddProductCommentViewModel? NewComment { get; set; }
    }
}
