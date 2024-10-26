using App.Data.Entities;

namespace App.Data.Data.Entities
{
    public class CartItemEntity
    {
        public int CartItemId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public byte Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserEntity User { get; set; } = null!;
        public ProductEntity Product { get; set; } = null!;
    }

}
