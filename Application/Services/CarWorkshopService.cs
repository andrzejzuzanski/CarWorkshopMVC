using Application.ApplicationUser;
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
        private readonly IUserContext _userContext;

        public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository, IMapper mapper, IUserContext userContext)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task Create(CarWorkshopDto carWorkshopDto)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDto);
            carWorkshop.EncodeName();
            carWorkshop.CreatedById = _userContext.GetCurrentUser().Id;
            await _carWorkshopRepository.Create(carWorkshop);
        }
        public async Task<IEnumerable<CarWorkshopDto>> GetAll()
        {
            var carWorkshops = await _carWorkshopRepository.GetAll();
            var carWorkshopDtos = _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops);
            return carWorkshopDtos;
        }

        public async Task<CarWorkshopDto> Details(int id)
        {
            var carWorkshop = await _carWorkshopRepository.Details(id);
            var carWorkshopDto = _mapper.Map<CarWorkshopDto>(carWorkshop);
            return carWorkshopDto;
        }

        public async Task Edit(int id, EditCarWorkshopDto editCarWorkshop)
        {
            var carWorkshop = await _carWorkshopRepository.Details(id);

            carWorkshop.Name = editCarWorkshop.Name;
            carWorkshop.Description = editCarWorkshop.Description;
            carWorkshop.ContactDetails.City = editCarWorkshop.City;
            carWorkshop.ContactDetails.PhoneNumber = editCarWorkshop.PhoneNumber;
            carWorkshop.ContactDetails.PostalCode = editCarWorkshop.PostalCode;
            carWorkshop.ContactDetails.Street = editCarWorkshop.Street;
            carWorkshop.EncodeName();

            await _carWorkshopRepository.Commit();
        }

        public async Task Delete(int id)
        {
            await _carWorkshopRepository.Delete(id);
        }
    }
}
