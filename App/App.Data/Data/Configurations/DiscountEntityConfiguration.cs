using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    internal class DiscountEntityConfiguration : IEntityTypeConfiguration<DiscountEntity>
    {
        public void Configure(EntityTypeBuilder<DiscountEntity> builder)
        {
            builder.HasKey(d => d.DiscountId);
            builder.Property(d => d.DiscountId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(d => d.DiscountRate)
                .IsRequired();
            builder.Property(d => d.StartDate)
                .IsRequired();
            builder.Property(d => d.EndDate)
                .IsRequired();
            builder.Property(d => d.Enabled)
                .IsRequired()
                .HasDefaultValue(true);
            builder.Property(d => d.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
