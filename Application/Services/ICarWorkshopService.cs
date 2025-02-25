using Application.CarWorkshop;
using Domain.Entities;

namespace Application.Services
{
    public interface ICarWorkshopService
    {
        Task Create(CarWorkshopDto carWorkshop);
        Task<IEnumerable<CarWorkshopDto>> GetAll();
        Task<CarWorkshopDto> Details(int id);
        Task Edit(int id,EditCarWorkshopDto editCarWorkshop);
        Task Delete(int id);
    }
}