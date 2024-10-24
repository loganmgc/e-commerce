using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Data.Configurations
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(r => r.RoleId);
            builder.Property(r => r.RoleId)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(r => r.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
