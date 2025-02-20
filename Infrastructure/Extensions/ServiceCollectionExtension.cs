using Domain.Interfaces;
using Infrastructure.Persistance;
using Infrastructure.Repositories;
using Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<CarWorkshopContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CarWorkshopDB")));

            service.AddScoped<CarWorkshopSeeder>();
            service.AddScoped<ICarWorkshopRepository, CarWorkshopRepository>();
        }
    }
}
