namespace App.Data.Data.Entities
{
    public class OrderEntity
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string OrderCode { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public UserEntity User { get; set; } = null!;
        public ICollection<OrderItemEntity>? OrderItems { get; set; }
    }
}
