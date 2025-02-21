﻿using Application.CarWorkshop;
using Domain.Entities;

namespace Application.Services
{
    public interface ICarWorkshopService
    {
        Task Create(CarWorkshopDto carWorkshop);
    }
}