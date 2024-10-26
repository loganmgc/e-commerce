using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    internal class BlogCommentEntityConfiguration : IEntityTypeConfiguration<BlogCommentEntity>
    {
        public void Configure(EntityTypeBuilder<BlogCommentEntity> builder)
        {
            builder.HasKey(b => b.BlogCommentId);
            builder.Property(b => b.BlogCommentId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(b => b.BlogId)
                .IsRequired();
            builder.HasOne(b => b.Blog)
                .WithMany(blog => blog.BlogComments)
                .HasForeignKey(b => b.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Comment)
                .IsRequired();
            builder.Property(b => b.IsApproved)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(b => b.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
