namespace App.Service.Models.ProductCommentDTOs
{
    public abstract class BaseProductCommentDto
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; } = null!;
        public byte StarCount { get; set; }
    }
}
