namespace App.Data.Data.Entities
{
    public class BlogEntity
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public int UserId { get; set; }
        public bool Enabled { get; set; } = true;
        public DateTime CreatedAt { get; set; }

        public UserEntity User { get; set; } = null!;
        public ICollection<BlogCommentEntity>? BlogComments { get; set; }
        public ICollection<RelBlogCategoryEntity>? RelCategories { get; set; }
        public ICollection<RelBlogTagEntity>? RelBlogTags { get; set; }
    }
}
