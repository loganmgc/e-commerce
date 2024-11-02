namespace App.Service.Models.ProductCommentDTOs
{
    public class GetCommentDto : BaseProductCommentDto
    {
        public int ProductCommentId { get; set; }
        public string ProductName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
