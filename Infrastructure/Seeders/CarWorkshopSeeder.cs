using Domain.Entities;
using Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopContext _context;

        public CarWorkshopSeeder(CarWorkshopContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.Database.CanConnectAsync())
            {
                if (!_context.CarWorkshops.Any())
                {
                    var seedData = new CarWorkshop()
                    {
                        Name = "Test car workshop",
                        Description = "Test description",
                        ContactDetails = new CarWorkshopContactDetails()
                        {
                            City = "Gliwice",
                            Street = "Andersa",
                            PostalCode = "44-123",
                            PhoneNumber = "773617281"
                        }
                    };
                    seedData.EncodeName();

                    _context.CarWorkshops.Add(seedData);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
