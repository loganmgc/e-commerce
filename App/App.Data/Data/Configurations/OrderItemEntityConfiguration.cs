using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItemEntity>
    {
        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.HasKey(o => o.OrderItemId);
            builder.Property(o => o.OrderItemId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(o => o.OrderId)
                .IsRequired();
            builder.HasOne(o => o.Order)
                .WithMany(or => or.OrderItems)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(o => o.ProductId)
                .IsRequired();
            builder.HasOne(o => o.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(o => o.Quantity)
                .IsRequired()
                .HasDefaultValue(1);
            builder.Property(o => o.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(o => o.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
