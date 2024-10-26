namespace App.Data.Data.Entities
{
    public class BlogCategoryEntity
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public ICollection<RelBlogCategoryEntity>? BlogCategories { get; set; }
    }
}
