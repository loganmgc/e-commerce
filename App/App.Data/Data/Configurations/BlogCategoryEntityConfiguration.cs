using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    internal class BlogCategoryEntityConfiguration : IEntityTypeConfiguration<BlogCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<BlogCategoryEntity> builder)
        {
            builder.HasKey(b => b.BlogCategoryId);
            builder.Property(b => b.BlogCategoryId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(b => b.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
