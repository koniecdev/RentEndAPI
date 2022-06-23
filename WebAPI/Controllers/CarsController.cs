using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly ICarService _carService;
		public CarsController(ICarService carService)
		{
			_carService = carService;
		}
		[HttpGet]
		public IActionResult Get()
		{
			var cars = _carService.GetAllCars();
			if(cars == null)
			{
				return NotFound();
			}
			return Ok(cars);
		}
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			if(id <= 0)
			{
				return NotFound();
			}
			var car = _carService.GetById(id);
			if(car == null)
			{
				return NotFound();
			}
			return Ok(car);
		}
		[HttpPost]
		public IActionResult Create(CreateCarDto createCarDto)
		{
			if(createCarDto == null)
			{
				return BadRequest();
			}
			if(string.IsNullOrWhiteSpace(createCarDto.Model))
			{
				return UnprocessableEntity();
			}
			var car = _carService.AddNewCar(createCarDto);
			return Created($"api/Cars/{car.Id}", car);
		}
		[HttpPatch("{id}")]
		public IActionResult Update(int id, UpdateCarDto updateCarDto)
		{
			if(id <= 0)
			{
				return NotFound();
			}
			var fromDb = _carService.GetById(id);
			if (fromDb == null)
			{
				return NotFound();
			}
			_carService.UpdateCar(id, updateCarDto);
			return NoContent();
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			if(id == 0)
			{
				return NotFound();
			}
			var fromDb = _carService.GetById(id);
			if(fromDb == null)
			{
				return NotFound();
			}
			_carService.DeleteCar(id);
			return NoContent();
		}
	}
}
