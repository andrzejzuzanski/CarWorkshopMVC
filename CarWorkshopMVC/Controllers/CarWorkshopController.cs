using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Application.CarWorkshop;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace CarWorkshopMVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;
        private readonly IMapper _mapper;

        public CarWorkshopController(ICarWorkshopService carWorkshopService, IMapper mapper)
        {
            _carWorkshopService = carWorkshopService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CarWorkshopDto newWorkshopDto)
        {
            if (ModelState.IsValid)
            {
                await _carWorkshopService.Create(newWorkshopDto);
                return RedirectToAction(nameof(Index));
            }
            return View(newWorkshopDto);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var carWorkshops = await _carWorkshopService.GetAll();
            return View(carWorkshops);
        }

        [HttpGet]
        [Route("CarWorkshop/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var carWorkshop = await _carWorkshopService.Details(id);
            return View(carWorkshop);
        }

        [HttpGet]
        [Route("CarWorkshop/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var carWorkshop = await _carWorkshopService.Details(id);
            var editDto = _mapper.Map<EditCarWorkshopDto>(carWorkshop);

            if (!editDto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }
            return View(editDto);

        }

        [HttpPost]
        [Route("CarWorkshop/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditCarWorkshopDto editCarWorkshop)
        {
            if (ModelState.IsValid)
            {
                await _carWorkshopService.Edit(id, editCarWorkshop);
                return RedirectToAction(nameof(Index));
            }
            return View(editCarWorkshop);
        }

    }
}
