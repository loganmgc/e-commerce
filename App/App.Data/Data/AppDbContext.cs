using App.Data.Data.Configurations;
using App.Data.Data.Entities;
using App.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<ProductImageEntity> ProductImages { get; set; }
    public DbSet<ProductCommentEntity> ProductComments { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CartItemEntity> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCommentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CartItemEntityConfiguration());

    }
}
