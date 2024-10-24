using App.Data.Entities;

namespace App.Data.Data.Entities
{
    public class CategoryEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string IconCssClass { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}
