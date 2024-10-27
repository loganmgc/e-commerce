using App.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Data
{
    internal static class DbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Random rnd = Random.Shared;

            modelBuilder.Entity<RoleEntity>().HasData(
               new RoleEntity() { RoleId = 1, Name = "admin" },
               new RoleEntity() { RoleId = 2, Name = "seller" },
               new RoleEntity() { RoleId = 3, Name = "buyer" }
            );

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity() { UserId = 1, FirstName = "admin", LastName = "admin", Email = "admin@gmail.com", Enabled = true, RoleId = 1, Password = "1234" },
                new UserEntity() { UserId = 2, FirstName = "seller", LastName = "seller", Email = "seller@gmail.com", Enabled = true, RoleId = 2, Password = "1234" },
                new UserEntity() { UserId = 3, FirstName = "buyer", LastName = "buyer", Email = "buyer@gmail.com", Enabled = true, RoleId = 3, Password = "1234" }
            );

            modelBuilder.Entity<CategoryEntity>().HasData(
                new List<CategoryEntity>{
                    new() {CategoryId = 1, Name = "Fresh Meat", Color = "Blue", IconCssClass = "fas fa-drumstick-bite"},
                    new() {CategoryId = 2, Name = "Vegetables", Color = "Red", IconCssClass = "fas fa-carrot"},
                    new() {CategoryId = 3, Name = "Fresh Fruits", Color = "Green", IconCssClass = "fas fa-apple-alt" },
                    new() {CategoryId = 4, Name = "Dried Fruits & Nuts", Color = "Brown", IconCssClass = "fas fa-seedling" },
                    new() {CategoryId = 5, Name = "Ocean Foods", Color = "Purple", IconCssClass = "fas fa-fish" },
                    new() {CategoryId = 6, Name = "Butter & Eggs", Color = "Yellow", IconCssClass = "fas fa-egg"},
                    new() {CategoryId = 7, Name = "Fastfood", Color = "Pink", IconCssClass = "fas fa-hamburger"},
                    new() {CategoryId = 8, Name = "Oatmeal", Color = "Grey", IconCssClass = "fas fa-bread-slice"},
                    new() {CategoryId = 9, Name = "Juices", Color = "Orange", IconCssClass = "fas fa-wine-glass-alt"}
                }
            );

            modelBuilder.Entity<DiscountEntity>().HasData(
                new List<DiscountEntity>
                {
                    new() {DiscountId = 1,DiscountRate = 10, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddMonths(6), Enabled = true},
                    new() {DiscountId = 2,DiscountRate = 20, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddMonths(6), Enabled = true},
                    new() {DiscountId = 3,DiscountRate = 30, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddMonths(6), Enabled = true}
                }
            );

            modelBuilder.Entity<ProductEntity>().HasData(
                new List<ProductEntity>{
                    new() {
                        ProductId = 1,
                        Name = "Mixed Fruit Juice",
                        CategoryId = 9,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Mixed Fruit Juice",
                        StockAmount = 100,
                        DiscountId = 2
                    },
                    new() {
                        ProductId = 2,
                        Name = "Mango",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Mango",
                        StockAmount = 50,
                        DiscountId = 2
                    },
                    new() {
                        ProductId = 3,
                        Name = "Hamburger",
                        CategoryId = 7,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Hamburger",
                        StockAmount = 20,
                        DiscountId = 2
                    },
                    new() {
                        ProductId = 4,
                        Name = "Red Meat",
                        CategoryId = 1,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Meat",
                        StockAmount = 50,
                    },
                    new() {
                        ProductId = 5,
                        Name = "Banana",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Banana",
                        StockAmount = 75,
                    },
                    new() {
                        ProductId = 6,
                        Name = "Fig",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Fig",
                        StockAmount = 100,
                    },
                    new() {
                        ProductId = 7,
                        Name = "Apple",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Apple",
                        StockAmount = 80,
                    },
                    new() {
                        ProductId = 8,
                        Name = "Grapes",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Grapes",
                        StockAmount = 100,
                    },
                    new() {
                        ProductId = 9,
                        Name = "Watermelon",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Watermelon",
                        StockAmount = 20,
                    },
                    new () {
                        ProductId = 10,
                        Name = "Raisins",
                        CategoryId = 4,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Raisins",
                        StockAmount = 100,
                    },
                    new() {
                        ProductId = 11,
                        Name = "Orange Juice",
                        CategoryId = 9,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Orange Juice",
                        StockAmount = 100,
                    },
                    new() {
                        ProductId = 12,
                        Name = "Mixed Fruits",
                        CategoryId = 3,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Mixed Fruits",
                        StockAmount = 100,
                    },
                    new() {
                        ProductId = 13,
                        Name = "Spinach",
                        CategoryId = 2,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Spinach",
                        StockAmount = 100,
                    },
                    new() {
                        ProductId = 14,
                        Name = "Bell Pepper",
                        CategoryId = 2,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Bell Pepper",
                        StockAmount = 100,
                    },
                    new() {
                        ProductId = 15,
                        Name = "Fried Chicken",
                        CategoryId = 7,
                        SellerId = 2,
                        Price = rnd.Next(10, 540),
                        Details = "Fried Chicken",
                        StockAmount = 20,
                    }
            });

            modelBuilder.Entity<ProductImageEntity>().HasData(
                new List<ProductImageEntity>
                {
                    new() {ProductImageId = 1, ProductId = 1, Url = "/theme/img/product/discount/pd-3.jpg"},
                    new() {ProductImageId = 2, ProductId = 2, Url = "/theme/img/product/discount/pd-4.jpg"},
                    new() {ProductImageId = 3, ProductId = 3, Url = "/theme/img/product/discount/pd-5.jpg"},
                    new() {ProductImageId = 4, ProductId = 4, Url = "/theme/img/product/product-1.jpg"},
                    new() {ProductImageId = 5, ProductId = 5, Url = "/theme/img/product/product-2.jpg"},
                    new() {ProductImageId = 6, ProductId = 6, Url = "/theme/img/product/product-3.jpg"},
                    new() {ProductImageId = 7, ProductId = 7, Url = "/theme/img/product/product-8.jpg"},
                    new() {ProductImageId = 8, ProductId = 8, Url = "/theme/img/product/product-4.jpg"},
                    new() {ProductImageId = 9, ProductId = 9, Url = "/theme/img/product/product-7.jpg"},
                    new() {ProductImageId = 10, ProductId = 10, Url = "/theme/img/product/product-9.jpg"},
                    new() {ProductImageId = 11, ProductId = 11, Url = "/theme/img/product/product-11.jpg"},
                    new() {ProductImageId = 12, ProductId = 12, Url = "/theme/img/product/product-12.jpg"},
                    new() {ProductImageId = 13, ProductId = 13, Url = "/theme/img/latest-product/lp-1.jpg"},
                    new() {ProductImageId = 14, ProductId = 14, Url = "/theme/img/product/details/product-details-2.jpg"},
                    new() {ProductImageId = 15,  ProductId = 15, Url = "/theme/img/product/product-10.jpg"}
                }
            );

            modelBuilder.Entity<BlogEntity>().HasData(
                new List<BlogEntity>
                {
                    new()
                    {
                        BlogId = 1,
                        Title = "Visit the clean farm in the US",
                        Content = "Visiting a clean farm in the US is an enlightening experience. The farm, with its well-maintained fields and healthy livestock, showcases the best of American agriculture. The cleanliness of the farm is a testament to the hard work and dedication of the farmers. They follow strict hygiene and cleanliness standards to ensure the health and safety of their animals and crops. The farm also uses sustainable farming practices to protect the environment. A visit to such a farm is not only educational but also inspiring, as it shows the importance of cleanliness and sustainability in farming.",
                        ImageUrl = "/theme/img/blog/blog-3.jpg",
                        UserId = 1
                    },
                    new()
                    {
                        BlogId = 2,
                        Title = "6 ways to prepare breakfast for 30",
                        Content = "Preparing breakfast for a large group requires careful planning and organization. Start by choosing recipes that can be made in large quantities, such as scrambled eggs, pancakes, or a breakfast casserole. Consider making items that can be prepared ahead of time, like muffins or fruit salad. Set up a serving station with all the necessary utensils, plates, and cups. Cook as much as you can in advance to minimize stress on the day of the event. Remember to cater to different dietary needs and preferences. With these tips, you'll be able to host a successful breakfast for 30 people.",
                        ImageUrl = "/theme/img/blog/blog-2.jpg",
                        UserId = 1
                    },
                    new()
                    {
                        BlogId = 3,
                        Title = "Cooking tips make cooking simple",
                        Content = "Cooking can be a daunting task for many, especially when it comes to preparing meals for a family or a large group. However, with the right tips and techniques, it can be made simple and enjoyable. Start by planning your meals in advance and doing a weekly grocery shop. This not only saves time but also ensures you have all the ingredients you need. Use fresh ingredients wherever possible as they provide the best flavor. Don't be afraid to experiment with different herbs and spices to add a unique twist to your dishes. Remember, the key to simple cooking is preparation and using the right tools. Invest in a good set of knives, pots, and pans. Lastly, don't forget to clean as you go. This will keep your kitchen tidy and make the cooking process much more manageable.",
                        ImageUrl = "/theme/img/blog/blog-1.jpg",
                        UserId = 1
                    },
                }
            );
        }
    }
}

