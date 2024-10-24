using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    public class ProductCommentEntityConfiguration : IEntityTypeConfiguration<ProductCommentEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCommentEntity> builder)
        {
            builder.HasKey(p => p.ProductCommentId);
            builder.Property(p => p.ProductCommentId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
            builder.Property(p => p.ProductId)
                .IsRequired();
            builder.HasOne(p => p.Product)
                .WithMany(p => p.ProductComments)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(p => p.UserId)
                .IsRequired();
            builder.HasOne(p => p.User)
                .WithMany(u => u.ProductComments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(p => p.Text)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(p => p.StarCount)
                .IsRequired()
                .HasDefaultValue(3);
            builder.Property(p => p.IsConfirmed)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
