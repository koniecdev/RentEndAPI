using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApplicationUsersController : ControllerBase
	{
		private readonly IApplicationUserService _service;
		public ApplicationUsersController(IApplicationUserService service)
		{
			_service = service;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var fromDb = await _service.GetAllApplicationUsers();
			if(fromDb == null)
			{
				return NotFound();
			}
			return Ok(fromDb);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(string id)
		{
			if(string.IsNullOrWhiteSpace(id))
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
		public async Task<IActionResult> Create(CreateApplicationUserDto dto, string password, string confirmpassword)
		{
			if (password != confirmpassword)
			{
				return ValidationProblem("Passwords not match");
			}
			if(dto == null)
			{
				return BadRequest();
			}
			if(string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(dto.Email))
			{
				return UnprocessableEntity();
			}
			var returned = await _service.AddNewApplicationUser(dto, password);
			return Created($"api/ApplicationUsers/{returned.Id}", returned);
		}
		[HttpPatch("{id}")]
		public async Task<IActionResult> Update(string id, UpdateApplicationUserDto dto)
		{
			if(string.IsNullOrWhiteSpace(id))
			{
				return BadRequest();
			}
			var fromDb = await _service.GetById(id);
			if (fromDb == null)
			{
				return NotFound();
			}
			await _service.UpdateApplicationUser(id, dto);
			return NoContent();
		}
		[HttpPatch]
		[Route("UpdatePassword/{id}")]
		public async Task<IActionResult> UpdatePassword(string id, string newPassword)
		{
			if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(newPassword))
			{
				return BadRequest();
			}
			var fromDb = await _service.GetById(id);
			if (fromDb == null)
			{
				return NotFound();
			}
			await _service.UpdateApplicationUser(id, newPassword);
			return NoContent();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				return NotFound();
			}
			var fromDb = await _service.GetById(id);
			if(fromDb == null)
			{
				return NotFound();
			}
			await _service.DeleteApplicationUser(id);
			return NoContent();
		}
	}
}
