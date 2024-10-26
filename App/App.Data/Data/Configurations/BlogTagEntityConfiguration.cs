using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    internal class BlogTagEntityConfiguration : IEntityTypeConfiguration<BlogTagEntity>
    {
        public void Configure(EntityTypeBuilder<BlogTagEntity> builder)
        {
            builder.HasKey(b => b.BlogTagId);
            builder.Property(b => b.BlogTagId)
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
