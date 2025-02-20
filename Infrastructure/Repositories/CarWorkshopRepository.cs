using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories
{
    internal class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopContext _context;

        public CarWorkshopRepository(CarWorkshopContext context)
        {
            _context = context;
        }

        public async Task Create(CarWorkshop carWorkshop)
        {
            _context.CarWorkshops.Add(carWorkshop);
            await _context.SaveChangesAsync();
        }
    }
}
