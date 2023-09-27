using DataAccessLayer.Data;
using DataAccessLayer.Implementation;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.EntityFrameworkCore;
using ModelLayer.DB;

namespace Product_CategoryModel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ProductCategoryDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<DbContext, ProductCategoryDbContext>();
            builder.Services.AddScoped<IRepo<Category>,Repo<Category>>();
            builder.Services.AddScoped<IRepo<Product>,Repo<Product>>();
            builder.Services.AddScoped<Icategory,CategoryRepo>();
            builder.Services.AddScoped<IProduct,ProductRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}