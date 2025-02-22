using Application.CarWorkshop;
using Domain.Entities;

namespace Application.Services
{
    public interface ICarWorkshopService
    {
        Task Create(CarWorkshopDto carWorkshop);
        Task<IEnumerable<CarWorkshopDto>> GetAll();
        Task<CarWorkshopDto> Details(string encodedName);
    }
}