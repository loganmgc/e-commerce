namespace App.Eticaret.Models.ViewModels.Product
{
    public class GetProductCommentViewModel
    {
        public int ProductCommentId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Text { get; set; } = null!;
        public byte StarCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
