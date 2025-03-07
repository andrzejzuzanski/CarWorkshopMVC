﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopContext _context;

        public CarWorkshopRepository(CarWorkshopContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Create(CarWorkshop carWorkshop)
        {
            _context.CarWorkshops.Add(carWorkshop);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarWorkshop>> GetAll()
        {
            var carWorkshops = await _context.CarWorkshops
                .AsNoTracking()
                .ToListAsync();
            return carWorkshops;
        }

        public async Task<CarWorkshop> Details(int id)
        {
            var carWorkshop = await _context.CarWorkshops.FirstAsync(cw => cw.Id == id);
            return carWorkshop;
        }

        public async Task Delete(int id)
        {
            var carWorkshopToDelete = _context.CarWorkshops.FirstOrDefault(cw => cw.Id == id);
            _context.CarWorkshops.Remove(carWorkshopToDelete!);
            await _context.SaveChangesAsync();
        }
    }
}
