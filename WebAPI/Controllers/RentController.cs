using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RentController : ControllerBase
	{
		private readonly IRentService _service;
		public RentController(IRentService service)
		{
			_service = service;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var fromDb = await _service.GetAllRents();
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
		[HttpGet]
		[Route("GetByDate/{departmentId}")]
		public async Task<IActionResult> Get(int departmentId, DateTime since, DateTime until)
		{
			if (departmentId <= 0)
			{
				return NotFound();
			}
			var fromDb = await _service.GetAllRents(departmentId, since, until);
			if (fromDb == null)
			{
				return NotFound();
			}
			return Ok(fromDb);
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateRentDto dto)
		{
			if(dto == null)
			{
				return BadRequest();
			}
			if(string.IsNullOrWhiteSpace(dto.UserId))
			{
				return UnprocessableEntity();
			}
			var returned = await _service.AddNewRent(dto);
			return Created($"api/Departments/{returned.Id}", returned);
		}
		[HttpPatch("{id}")]
		public async Task<IActionResult> Update(int id, UpdateRentDto dto)
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
			await _service.UpdateRent(id, dto);
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
			await _service.DeleteRent(id);
			return NoContent();
		}
	}
}
