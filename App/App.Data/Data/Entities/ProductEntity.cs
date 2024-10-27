namespace App.Data.Data.Entities
{
    public class ProductEntity
    {
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public int? DiscountId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Details { get; set; } = null!;
        public byte StockAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Enabled { get; set; } = true;

        public UserEntity Seller { get; set; } = null!;
        public CategoryEntity Category { get; set; } = null!;
        public DiscountEntity? Discount { get; set; }
        public ICollection<ProductCommentEntity>? ProductComments { get; set; }
        public ICollection<CartItemEntity>? CartItems { get; set; }
        public ICollection<OrderItemEntity>? OrderItems { get; set; }
        public ICollection<ProductImageEntity> ProductImages { get; set; } = null!;
    }
}
