using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentsController : ControllerBase
	{
		private readonly IDepartmentService _service;
		public DepartmentsController(IDepartmentService service)
		{
			_service = service;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var fromDb = await _service.GetAllDepartments();
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
		public async Task<IActionResult> Create(CreateDepartmentDto dto)
		{
			if(dto == null)
			{
				return BadRequest();
			}
			if(string.IsNullOrWhiteSpace(dto.City) || string.IsNullOrWhiteSpace(dto.FullAddress))
			{
				return UnprocessableEntity();
			}
			var returned = await _service.AddNewDepartment(dto);
			return Created($"api/Departments/{returned.Id}", returned);
		}
		[HttpPatch("{id}")]
		public async Task<IActionResult> Update(int id, UpdateDepartmentDto dto)
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
			await _service.UpdateDepartment(id, dto);
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
			await _service.DeleteDepartment(id);
			return NoContent();
		}
	}
}
