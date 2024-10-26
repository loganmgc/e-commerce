using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    internal class BlogEntityConfiguration : IEntityTypeConfiguration<BlogEntity>
    {
        public void Configure(EntityTypeBuilder<BlogEntity> builder)
        {
            builder.HasKey(b => b.BlogId);
            builder.Property(b => b.BlogId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Content)
                .IsRequired();
            builder.Property(b => b.ImageUrl)
                .HasMaxLength(256);
            builder.Property(b => b.UserId)
                .IsRequired();
            builder.HasOne(b => b.User)
                .WithMany(u => u.Blogs)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(b => b.Enabled)
                .IsRequired()
                .HasDefaultValue(true);
            builder.Property(b => b.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
