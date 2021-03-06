using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PinsController : ControllerBase
	{
		private readonly IPinService _service;
		public PinsController(IPinService service)
		{
			_service = service;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var fromDb = await _service.GetAllPins();
			if(fromDb == null)
			{
				return NotFound();
			}
			return Ok(fromDb);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			if(id <= 0)
			{
				return NotFound();
			}
			var fromDb = await _service.GetById(id);
			if(fromDb == null)
			{
				return NotFound();
			}
			return Ok(fromDb);
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreatePinDto dto)
		{
			if(dto == null)
			{
				return BadRequest();
			}
			if (dto.CarId <= 0)
			{
				return UnprocessableEntity();
			}
			var returned = await _service.AddNewPin(dto);
			return Created($"api/Pins/{returned.Id}", returned);
		}
		[HttpPatch("{id}")]
		public async Task<IActionResult> Update(int id, UpdatePinDto dto)
		{
			if(id <= 0)
			{
				return NotFound();
			}
			var fromDb = await _service.GetById(id);
			if (fromDb == null)
			{
				return NotFound();
			}
			await _service.UpdatePin(id, dto);
			return NoContent();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if(id == 0)
			{
				return NotFound();
			}
			var fromDb = await _service.GetById(id);
			if(fromDb == null)
			{
				return NotFound();
			}
			await _service.DeletePin(id);
			return NoContent();
		}
	}
}
