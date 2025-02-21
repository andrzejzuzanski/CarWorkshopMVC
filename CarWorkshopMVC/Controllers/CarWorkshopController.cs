using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Application.CarWorkshop;

namespace CarWorkshopMVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;

        public CarWorkshopController(ICarWorkshopService carWorkshopService)
        {
            _carWorkshopService = carWorkshopService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopDto newWorkshopDto)
        {
            if (ModelState.IsValid)
            {
                await _carWorkshopService.Create(newWorkshopDto);
                return RedirectToAction(nameof(Create));
            }
            return View(newWorkshopDto);
        }
    }
}
