using App.Data;
using App.Data.Repositories.Implenemtations;
using App.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using App.Service.Helpers;
using App.Service.Services.Implementations;
using App.Service.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    options.UseSqlServer(connectionString);
});

builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "Eticaret";
    options.Cookie.HttpOnly = true;
    options.IdleTimeout = TimeSpan.FromMinutes(5);
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/login";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
});

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductCommentRepository, ProductCommentRepository>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductCommentService, ProductCommentService>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<ProductHelper>();
builder.Services.AddScoped<ProductCommentHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    using (var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
    {
        //await dbContext.Database.EnsureDeletedAsync();

        bool isNewlyCreated = await dbContext.Database.EnsureCreatedAsync();
        if (isNewlyCreated)
        {
            await DbSeed.SeedAsync(dbContext);
        }
    }
}

app.Run();