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
		public IActionResult Get()
		{
			var fromDb = _service.GetAllDepartments();
			if(fromDb == null)
			{
				return NotFound();
			}
			return Ok(fromDb);
		}
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			if(id <= 0)
			{
				return NotFound();
			}
			var fromDb = _service.GetById(id);
			if(fromDb == null)
			{
				return NotFound();
			}
			return Ok(fromDb);
		}
		[HttpPost]
		public IActionResult Create(CreateDepartmentDto dto)
		{
			if(dto == null)
			{
				return BadRequest();
			}
			if(string.IsNullOrWhiteSpace(dto.City) || string.IsNullOrWhiteSpace(dto.FullAddress))
			{
				return UnprocessableEntity();
			}
			var returned = _service.AddNewDepartment(dto);
			return Created($"api/Departments/{returned.Id}", returned);
		}
		[HttpPatch("{id}")]
		public IActionResult Update(int id, UpdateDepartmentDto dto)
		{
			if(id <= 0)
			{
				return NotFound();
			}
			var fromDb = _service.GetById(id);
			if (fromDb == null)
			{
				return NotFound();
			}
			_service.UpdateDepartment(id, dto);
			return NoContent();
		}
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			if(id == 0)
			{
				return NotFound();
			}
			var fromDb = _service.GetById(id);
			if(fromDb == null)
			{
				return NotFound();
			}
			_service.DeleteDepartment(id);
			return NoContent();
		}
	}
}
