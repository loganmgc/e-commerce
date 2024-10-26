using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    internal class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(o => o.OrderId);
            builder.Property(o => o.OrderId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(o => o.UserId)
                .IsRequired();
            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(o => o.OrderCode)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(o => o.Address)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(o => o.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
