using Application.CarWorkshop;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }
        public async Task Create(CarWorkshopDto carWorkshopDto)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDto);
            carWorkshop.EncodeName();
            await _carWorkshopRepository.Create(carWorkshop);
        }

        public async Task<CarWorkshopDto> Details(string encodedName)
        {
            var carWorkshop = await _carWorkshopRepository.Details(encodedName);
            var carWorkshopDto = _mapper.Map<CarWorkshopDto>(carWorkshop);
            return carWorkshopDto;
        }

        public async Task<IEnumerable<CarWorkshopDto>> GetAll()
        {
            var carWorkshops = await _carWorkshopRepository.GetAll();
            var carWorkshopDtos = _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops);
            return carWorkshopDtos;
        }
    }
}
