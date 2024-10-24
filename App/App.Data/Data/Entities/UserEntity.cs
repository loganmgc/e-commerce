using App.Data.Entities;

namespace App.Data.Data.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; }

        public RoleEntity Role { get; set; }
        public ICollection<ProductEntity>? Products { get; set; }
        public ICollection<ProductCommentEntity>? ProductComments { get; set; }
        public ICollection<CartItemEntity> CartItems { get; set; }
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
