using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;

        public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository)
        {
            _carWorkshopRepository = carWorkshopRepository;
        }
        public async Task Create(CarWorkshop carWorkshop)
        {
            carWorkshop.EncodeName();
            await _carWorkshopRepository.Create(carWorkshop);
        }
    }
}
