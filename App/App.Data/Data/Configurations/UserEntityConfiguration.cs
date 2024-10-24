using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.UserId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(u => u.Email)
                .IsRequired();
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(u => u.Password)
                .IsRequired();
            builder.Property(u => u.RoleId)
                .IsRequired()
                .HasDefaultValue(1);
            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.NoAction);
            builder.Property(u => u.Enabled)
                .IsRequired()
                .HasDefaultValue(true);
            builder.Property(u => u.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
