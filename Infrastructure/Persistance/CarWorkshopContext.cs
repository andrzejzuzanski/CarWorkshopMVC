using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class CarWorkshopContext : DbContext
    {
        public DbSet<CarWorkshop> CarWorkshops { get; set; }

        public CarWorkshopContext(DbContextOptions<CarWorkshopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarWorkshop>(cw =>
            {
                cw.OwnsOne(cw => cw.ContactDetails);
            });
        }
    }
}
