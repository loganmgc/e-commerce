namespace App.Data.Data.Entities
{
    public class RelBlogTagEntity
    {
        public int RelBlogTagId { get; set; }
        public int BlogId { get; set; }
        public int TagId { get; set; }
        public DateTime CreatedAt { get; set; }

        public BlogEntity Blog { get; set; } = null!;
        public BlogTagEntity Tag { get; set; } = null!;
    }
}
