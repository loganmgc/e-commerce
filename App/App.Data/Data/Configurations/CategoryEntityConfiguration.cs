using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Color)
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(c => c.IconCssClass)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
