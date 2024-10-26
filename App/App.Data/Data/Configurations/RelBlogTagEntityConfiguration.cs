using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    internal class RelBlogTagEntityConfiguration : IEntityTypeConfiguration<RelBlogTagEntity>
    {
        public void Configure(EntityTypeBuilder<RelBlogTagEntity> builder)
        {
            builder.HasKey(r => r.RelBlogTagId);
            builder.Property(r => r.RelBlogTagId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(r => r.BlogId)
                .IsRequired();
            builder.HasOne(r => r.Blog)
                .WithMany(b => b.RelBlogTags)
                .HasForeignKey(r => r.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(r => r.TagId)
                .IsRequired();
            builder.HasOne(r => r.Tag)
                .WithMany(bt => bt.RelBlogTags)
                .HasForeignKey(r => r.TagId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(r => r.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
