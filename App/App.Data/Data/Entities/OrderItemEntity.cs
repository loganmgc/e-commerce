using App.Data.Entities;

namespace App.Data.Data.Entities
{
    public class OrderItemEntity
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }

        public OrderEntity Order { get; set; } = null!;
        public ProductEntity Product { get; set; } = null!;
    }
}
