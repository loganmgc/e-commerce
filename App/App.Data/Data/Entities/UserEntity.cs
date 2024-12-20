﻿namespace App.Data.Data.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; } = 3;
        public bool Enabled { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public bool HasSellerRequest { get; set; } = false;
        public string? ResetPasswordToken { get; set; }

        public RoleEntity Role { get; set; } = null!;
        public ICollection<ProductEntity>? Products { get; set; }
        public ICollection<ProductCommentEntity>? ProductComments { get; set; }
        public ICollection<CartItemEntity>? CartItems { get; set; }
        public ICollection<OrderEntity>? Orders { get; set; }
        public ICollection<BlogEntity>? Blogs { get; set; }
    }
}
