using App.Data.Entities;

namespace App.Data.Data.Entities
{
    public class ProductImageEntity
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; } = null!;
        public DateTime CraetedAt { get; set; }

        public ProductEntity Product { get; set; } = null!;
    }
}
