using App.Data.Entities;

namespace App.Data.Data.Entities
{
    public class ProductCommentEntity
    {
        public int ProductCommentId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; } = null!;
        public byte StarCount { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime CreatedAt { get; set; }

        public ProductEntity Product { get; set; } = null!;
        public UserEntity User { get; set; } = null!;
    }
}
