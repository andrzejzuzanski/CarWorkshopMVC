using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Application.CarWorkshop;
using AutoMapper;

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
                return RedirectToAction(nameof(Index));
            }
            return View(newWorkshopDto);
        }

        [HttpPost]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditCarWorkshopDto editCarWorkshop)
        {
            if (ModelState.IsValid)
            {
                await _carWorkshopService.Edit(encodedName, editCarWorkshop);
                return RedirectToAction(nameof(Index));
            }
            return View(editCarWorkshop);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var carWorkshops = await _carWorkshopService.GetAll();
            return View(carWorkshops);
        }

        [HttpGet]
        [Route("CarWorkshop/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var carWorkshop = await _carWorkshopService.Details(encodedName);
            return View(carWorkshop);
        }

        [HttpGet]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var carWorkshop = await _carWorkshopService.Details(encodedName);
            var editDto = _mapper.Map<EditCarWorkshopDto>(carWorkshop);

            return View(editDto);
        }

    }
}
