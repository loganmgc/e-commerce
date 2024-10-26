
namespace App.Service.Models.BlogDTOs
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public int? CommentCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
