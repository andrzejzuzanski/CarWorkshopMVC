using Domain.Entities;

namespace Application.Services
{
    public interface ICarWorkshopService
    {
        Task Create(CarWorkshop carWorkshop);
    }
}