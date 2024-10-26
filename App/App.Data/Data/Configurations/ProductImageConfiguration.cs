using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    internal class ProductImageConfiguration : IEntityTypeConfiguration<ProductImageEntity>
    {
        public void Configure(EntityTypeBuilder<ProductImageEntity> builder)
        {
            builder.HasKey(p => p.ProductImageId);
            builder.Property(p => p.ProductImageId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(p => p.ProductId)
                .IsRequired();
            builder.Property(p => p.Url)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(p => p.CraetedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
            builder.HasOne(p => p.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
