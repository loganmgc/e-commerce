namespace App.Data.Data.Entities
{
    public class BlogTagEntity
    {
        public int BlogTagId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public ICollection<RelBlogTagEntity>? RelBlogTags { get; set; }
    }
}
