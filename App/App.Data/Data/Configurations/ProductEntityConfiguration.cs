using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    internal class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(p => p.SellerId)
                .IsRequired();
            builder.HasOne(p => p.Seller)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.CategoryId)
                .IsRequired();
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(p => p.Details)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(p => p.StockAmount)
                .IsRequired();
            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.Enabled)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
