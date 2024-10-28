namespace App.Admin.Models.ViewModels.Comment
{
    public class CommentListViewModel
    {
        public int ProductCommentId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Text { get; set; } = null!;
        public byte StarCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
