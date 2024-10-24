using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    public class CartItemEntityConfiguration : IEntityTypeConfiguration<CartItemEntity>
    {
        public void Configure(EntityTypeBuilder<CartItemEntity> builder)
        {
            builder.HasKey(c => c.CartItemId);
            builder.Property(c => c.CartItemId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(c => c.UserId)
                .IsRequired();
            builder.HasOne(c => c.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(c => c.ProductId)
                .IsRequired();
            builder.HasOne(c => c.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(c => c.Quantity)
                .IsRequired()
                .HasDefaultValue((byte)1);
            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
