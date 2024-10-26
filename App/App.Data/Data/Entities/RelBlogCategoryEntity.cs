
namespace App.Data.Data.Entities
{
    public class RelBlogCategoryEntity
    {
        public int RelBlogCategoryId { get; set; }
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }

        public BlogEntity Blog { get; set; } = null!;
        public BlogCategoryEntity BlogCategory { get; set; } = null!;
    }
}
