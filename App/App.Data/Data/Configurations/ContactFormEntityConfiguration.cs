using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    internal class ContactFormEntityConfiguration : IEntityTypeConfiguration<ContactFormEntity>
    {
        public void Configure(EntityTypeBuilder<ContactFormEntity> builder)
        {
            builder.HasKey(c => c.ContacFormId);
            builder.Property(c => c.ContacFormId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(c => c.Message)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
