using App.Data.Data.Entities;

namespace App.Data
{
    public static class DbSeed
    {
        public static async Task SeedAsync(AppDbContext dbContext)
        {
            var roles = new List<RoleEntity>
            {
                new RoleEntity {Name = "Buyer"},
                new RoleEntity {Name = "Seller"},
                new RoleEntity {Name = "Admin"}
            };
            dbContext.Roles.AddRange(roles);
            await dbContext.SaveChangesAsync();

            var users = new List<UserEntity>
            {
                new UserEntity {
                    Email = "mahmuttuncer@gmail.com",
                    FirstName = "Mahmut",
                    LastName = "Tuncer",
                    Password = "123456",
                    RoleId = 3,
                    Enabled = true
                },
                new UserEntity
                {
                    Email = "seller@gmail.com",
                    FirstName = "Seller",
                    LastName = "Mahmut",
                    Password = "123457",
                    RoleId = 2,
                    Enabled = true
                },
                new UserEntity
                {
                    Email = "buyyer@gmail.com",
                    FirstName = "Buyyer",
                    LastName = "Mahmut",
                    Password = "1234567",
                    RoleId = 1,
                    Enabled = true
                }
            };
            dbContext.Users.AddRange(users);

            var categories = new List<CategoryEntity>
            {
                new CategoryEntity
                {
                    Name = "Electronics",
                    Color = "007bff",
                    IconCssClass = "fas fa-plug"
                },
                new CategoryEntity
                {
                    Name = "Clothing",
                    Color = "f0ad4e",
                    IconCssClass = "fas fa-tshirt"
                },
                new CategoryEntity
                {
                    Name = "Home & Living",
                    Color = "9d38bd",
                    IconCssClass = "fas fa-home"
                },
                new CategoryEntity
                {
                    Name = "Beauty & Wellness ",
                    Color = "dc3545",
                    IconCssClass = "fas fa-spa"
                },
                new CategoryEntity
                {
                    Name = "Books & Stationery",
                    Color = "28a745",
                    IconCssClass = "fas fa-book"
                },
                new CategoryEntity
                {
                    Name = "Sports & Outdoors",
                    Color = "ffc107",
                    IconCssClass = "fas fa-running"
                },
                new CategoryEntity
                {
                    Name = "Food & Drinks",
                    Color = "20c997",
                    IconCssClass = "fas fa-utensils"
                },
                new CategoryEntity
                {
                    Name = "Toys & Games",
                    Color = "ff9500",
                    IconCssClass = "fas fa-gamepad"
                },
                new CategoryEntity
                {
                    Name = "Arts & Crafts",
                    Color = "7f7f7f",
                    IconCssClass = "fas fa-palette"
                },
                new CategoryEntity
                {
                    Name = "Travel & Accessories",
                    Color = "38a3a5",
                    IconCssClass = "fas fa-suitcase"
                }
            };
            dbContext.Categories.AddRange(categories);
            await dbContext.SaveChangesAsync();
        }
    }
}
