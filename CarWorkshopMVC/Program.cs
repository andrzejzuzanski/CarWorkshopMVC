using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Extensions;
using Infrastructure.Seeders;
using Application.Extensions;

namespace CarWorkshopMVC
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            // SQL Server configuration
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<CarWorkshopSeeder>();
            await seeder.Seed();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=CarWorkshop}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages();
            app.Run();
        }
    }
}
