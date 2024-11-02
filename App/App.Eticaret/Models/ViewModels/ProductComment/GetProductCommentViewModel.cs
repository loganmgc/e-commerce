namespace App.Eticaret.Models.ViewModels.ProductComment
{
    public class GetProductCommentViewModel :BaseProductCommentViewModel
    {
        public int ProductCommentId { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
