using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        Task Create(CarWorkshop carWorkshop);
        Task<IEnumerable<CarWorkshop>> GetAll();
        Task<CarWorkshop> Details(string encodedName);
    }
}
