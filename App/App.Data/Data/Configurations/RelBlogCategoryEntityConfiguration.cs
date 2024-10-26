using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    internal class RelBlogCategoryEntityConfiguration : IEntityTypeConfiguration<RelBlogCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<RelBlogCategoryEntity> builder)
        {
            builder.HasKey(r => r.RelBlogCategoryId);
            builder.Property(r => r.RelBlogCategoryId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(r => r.BlogId)
                .IsRequired();
            builder.HasOne(r => r.Blog)
                .WithMany(b => b.RelCategories)
                .HasForeignKey(r => r.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(r => r.CategoryId)
                .IsRequired();
            builder.HasOne(r => r.BlogCategory)
                .WithMany(bc => bc.BlogCategories)
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(r => r.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
